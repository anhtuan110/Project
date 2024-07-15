const express = require('express');
const bodyParser = require('body-parser');
const mysql = require('mysql');
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');

const app = express();
const port = 3000;

app.use(bodyParser.json());

// Cấu hình kết nối MySQL
const db = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'mydatabase'
});

db.connect(err => {
  if (err) {
    throw err;
  }
  console.log('MySQL connected...');
});

// Middleware xác thực JWT
const authenticateToken = (req, res, next) => {
  const token = req.headers['authorization'];
  if (!token) return res.sendStatus(401);

  jwt.verify(token, 'SECRET_KEY', (err, user) => {
    if (err) return res.sendStatus(403);
    req.user = user;
    next();
  });
};

// Đăng ký người dùng
app.post('/api/register', (req, res) => {
  const { name, username, password, avatar, role } = req.body;

  const sql = 'INSERT INTO users (name, username, password, avatar, role) VALUES (?, ?, ?, ?, ?)';
  db.query(sql, [name, username, password, avatar, role], (err, result) => {
    if (err) throw err;
    res.send('User registered');
  });
});

// Đăng nhập
app.post('/api/login', (req, res) => {
  const { username, password } = req.body;
  const sql = 'SELECT * FROM users WHERE username = ? AND password = ?';
  db.query(sql, [username, password], (err, results) => {
    if (err) throw err;
    if (results.length > 0) {
      const user = results[0];
      res.json({ message: 'Login successful', id: user.id, role: user.role });
    } else {
      res.status(401).send('Username or password incorrect');
    }
  });
});



// Lấy tất cả câu hỏi
app.get('/api/questions', (req, res) => {
  const sql = `
    SELECT 
      questions.id, questions.content, questions.user_id, questions.created_at,
      users.name, users.avatar
    FROM 
      questions 
    JOIN 
      users 
    ON 
      questions.user_id = users.id
  `;
  db.query(sql, (err, results) => {
    if (err) {
      console.error('Error fetching questions:', err);
      return res.status(500).json({ error: 'Database error' });
    }
    res.json(results);
  });
});


// Lấy bình luận của một câu hỏi
app.get('/comments/:question_id', (req, res) => {
  const questionId = req.params.question_id;

  const query = `
      SELECT 
          comments.id, 
          comments.content, 
          comments.created_at, 
          users.name AS user_name, 
          users.avatar AS user_avatar 
      FROM comments 
      JOIN users ON comments.user_id = users.id 
      WHERE comments.question_id = ? 
      ORDER BY comments.created_at DESC
  `;

  db.query(query, [questionId], (err, results) => {
      if (err) {
          console.error('Lỗi khi truy vấn cơ sở dữ liệu:', err);
          res.status(500).send('Lỗi máy chủ');
          return;
      }
      res.json(results);
  });
});


// API để đăng bình luận cho một câu hỏi
app.post('/comments', (req, res) => {
  const { content, user_id, question_id } = req.body;

  if (!content || !user_id || !question_id) {
      return res.status(400).send('Thiếu thông tin yêu cầu');
  }

  const query = `
      INSERT INTO comments (content, user_id, question_id, created_at) 
      VALUES (?, ?, ?, NOW())
  `;

  db.query(query, [content, user_id, question_id], (err, results) => {
      if (err) {
          console.error('Lỗi khi thêm bình luận:', err);
          res.status(500).send('Lỗi máy chủ');
          return;
      }
      res.status(201).send('Bình luận đã được thêm');
  });
});


app.post('/api/addQuestion', (req, res) => {
  const { user_id, question } = req.body;
  const sql = 'INSERT INTO questions (user_id, content) VALUES (?, ?)';
  db.query(sql, [user_id, question], (err, result) => {
    if (err) {
      console.error('Error adding question:', err);
      return res.status(500).json({ error: 'Database error' });
    }
    res.send('Question added');
  });
});


// API để liệt kê tất cả người dùng
app.get('/users', (req, res) => {
  const query = 'SELECT * FROM users';

  db.query(query, (err, results) => {
      if (err) {
          console.error('Lỗi khi truy vấn cơ sở dữ liệu:', err);
          res.status(500).send('Lỗi máy chủ');
          return;
      }
      res.json(results);
  });
});

// API để cập nhật thông tin người dùng

app.put('/users/:id', (req, res) => {
  const userId = req.params.id;
  const { username, password } = req.body;


  const query = `
      UPDATE users 
      SET username = ?, password = ? 
      WHERE id = ?
  `;

  db.query(query, [username, password, userId], (err, results) => {
      if (err) {
          console.error('Lỗi khi cập nhật thông tin người dùng:', err);
          res.status(500).send('Lỗi máy chủ');
          return;
      }
      if (results.affectedRows === 0) {
          res.status(404).send('Không tìm thấy người dùng');
      } else {
          res.send('Cập nhật thông tin người dùng thành công');
      }
  });
});


// API để xóa người dùng và tất cả các thuộc tính liên quan
app.delete('/users/:id', (req, res) => {
  const userId = req.params.id;

  // Xóa bình luận liên quan đến câu hỏi của người dùng
  const deleteCommentsByQuestionsQuery = `
      DELETE comments FROM comments 
      JOIN questions ON comments.question_id = questions.id 
      WHERE questions.user_id = ?
  `;

  db.query(deleteCommentsByQuestionsQuery, [userId], (err, results) => {
      if (err) {
          console.error('Lỗi khi xóa bình luận liên quan đến câu hỏi của người dùng:', err);
          res.status(500).send('Lỗi máy chủ');
          return;
      }

      // Xóa bình luận của người dùng
      const deleteCommentsQuery = 'DELETE FROM comments WHERE user_id = ?';

      db.query(deleteCommentsQuery, [userId], (err, results) => {
          if (err) {
              console.error('Lỗi khi xóa bình luận của người dùng:', err);
              res.status(500).send('Lỗi máy chủ');
              return;
          }

          // Xóa câu hỏi của người dùng
          const deleteQuestionsQuery = 'DELETE FROM questions WHERE user_id = ?';

          db.query(deleteQuestionsQuery, [userId], (err, results) => {
              if (err) {
                  console.error('Lỗi khi xóa câu hỏi của người dùng:', err);
                  res.status(500).send('Lỗi máy chủ');
                  return;
              }

              // Xóa người dùng
              const deleteUserQuery = 'DELETE FROM users WHERE id = ?';

              db.query(deleteUserQuery, [userId], (err, results) => {
                  if (err) {
                      console.error('Lỗi khi xóa người dùng:', err);
                      res.status(500).send('Lỗi máy chủ');
                      return;
                  }
                  if (results.affectedRows === 0) {
                      res.status(404).send('Không tìm thấy người dùng');
                  } else {
                      res.send('Xóa người dùng và các thuộc tính liên quan thành công');
                  }
              });
          });
      });
  });
});
app.get('/questions/:userId', (req, res) => {
  const userId = req.params.userId;
  const query = 'SELECT * FROM questions WHERE user_id = ?';

  db.query(query, [userId], (err, results) => {
      if (err) {
          console.error('Error fetching questions:', err);
          res.status(500).send('Internal Server Error');
          return;
      }
      res.json(results);
  });
});

app.put('/questions/:id', (req, res) => {
  const questionId = req.params.id;
  const { content } = req.body;
  const query = 'UPDATE questions SET content = ? WHERE id = ?';

  db.query(query, [content, questionId], (err, results) => {
      if (err) {
          console.error('Error updating question:', err);
          res.status(500).send('Internal Server Error');
          return;
      }
      res.json({ message: 'Question updated successfully' });
  });
});

// Delete a question by ID
app.delete('/questions/:id', (req, res) => {
  const questionId = req.params.id;
  
  db.beginTransaction(err => {
      if (err) {
          console.error('Error starting transaction:', err);
          res.status(500).send('Internal Server Error');
          return;
      }
      
      const deleteCommentsQuery = 'DELETE FROM comments WHERE question_id = ?';
      db.query(deleteCommentsQuery, [questionId], (err, results) => {
          if (err) {
              return db.rollback(() => {
                  console.error('Error deleting comments:', err);
                  res.status(500).send('Internal Server Error');
              });
          }

          const deleteQuestionQuery = 'DELETE FROM questions WHERE id = ?';
          db.query(deleteQuestionQuery, [questionId], (err, results) => {
              if (err) {
                  return db.rollback(() => {
                      console.error('Error deleting question:', err);
                      res.status(500).send('Internal Server Error');
                  });
              }
              
              db.commit(err => {
                  if (err) {
                      return db.rollback(() => {
                          console.error('Error committing transaction:', err);
                          res.status(500).send('Internal Server Error');
                      });
                  }
                  res.json({ message: 'Question and related comments deleted successfully' });
              });
          });
      });
  });
});

// API để lấy danh sách các dịch vụ
app.get('/services', (req, res) => {
  const query = 'SELECT * FROM services';
  db.query(query, (err, results) => {
      if (err) {
          return res.status(500).json({ error: err });
      }
      res.json(results);
  });
});

app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});

