package com.example.myapplication;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class CommentsActivity extends AppCompatActivity {
    private TextView textViewQuestionDetail;
    private RecyclerView recyclerViewComments;
    private EditText editTextComment;
    private Button buttonSubmitComment;
    private CommentAdapter commentAdapter;
    private ArrayList<Comment> comments;
    private int questionId;
    private String question;
    private SharedPreferences sharedPreferences;
    private int loggedInUserId = -1;
    private ImageButton btnBack;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_comments);

        textViewQuestionDetail = findViewById(R.id.textViewQuestionDetail);
        recyclerViewComments = findViewById(R.id.recyclerViewComments);
        editTextComment = findViewById(R.id.editTextComment);
        buttonSubmitComment = findViewById(R.id.buttonSubmitComment);

        comments = new ArrayList<>();
        commentAdapter = new CommentAdapter(this, comments);

        recyclerViewComments.setLayoutManager(new LinearLayoutManager(this));
        recyclerViewComments.setAdapter(commentAdapter);
        sharedPreferences = getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
        loggedInUserId = sharedPreferences.getInt("id", -1);

        questionId = getIntent().getIntExtra("questionID", -1);
        String questionText = getIntent().getStringExtra("question");

        btnBack = findViewById(R.id.btnBack);
        btnBack.setOnClickListener(v -> onBackPressed());

        if (questionId == -1) {
            Toast.makeText(this, "Invalid Question ID", Toast.LENGTH_SHORT).show();
            finish();
            return;
        }
        loadQuestionDetail(questionText);
        loadComments(questionId);


        buttonSubmitComment.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String content = editTextComment.getText().toString().trim();
                if (!TextUtils.isEmpty(content)) {
                    postComment(content, 1, questionId);
                } else {
                    Toast.makeText(CommentsActivity.this, "Comment cannot be empty", Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void loadQuestionDetail(String questionId) {
        textViewQuestionDetail.setText(" " + questionId);
    }

    private void postComment(String content, int userId, int questionId) {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/comments");
                HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                conn.setRequestMethod("POST");
                conn.setRequestProperty("Content-Type", "application/json; charset=UTF-8");
                conn.setDoOutput(true);

                JSONObject jsonParam = new JSONObject();
                jsonParam.put("user_id", userId);
                jsonParam.put("content", content);
                jsonParam.put("question_id", questionId);

                OutputStream os = conn.getOutputStream();
                os.write(jsonParam.toString().getBytes("UTF-8"));
                os.close();

                int responseCode = conn.getResponseCode();
                if (responseCode == HttpURLConnection.HTTP_OK) {
                    runOnUiThread(() -> {
                        Toast.makeText(this, "Comment added successfully", Toast.LENGTH_SHORT).show();
                        loadComments(questionId); // Load lại danh sách comments sau khi thêm thành công
                    });
                } else {
                    runOnUiThread(() -> {
                        editTextComment.setText("");
                        Toast.makeText(this, "Comment added successfully", Toast.LENGTH_SHORT).show();
                        loadComments(questionId);
                    });
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        });

        try {
            future.get();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void loadComments(int questionId) {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/comments/" + questionId);
                HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                conn.setRequestMethod("GET");

                int responseCode = conn.getResponseCode();
                if (responseCode == HttpURLConnection.HTTP_OK) {
                    BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream(), "UTF-8"));
                    StringBuilder response = new StringBuilder();
                    String responseLine;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    br.close();

                    // Xóa danh sách comments cũ
                    comments.clear();

                    JSONArray commentsArray = new JSONArray(response.toString());
                    for (int i = 0; i < commentsArray.length(); i++) {
                        JSONObject commentObj = commentsArray.getJSONObject(i);
                        String username = commentObj.getString("user_name");
                        String avatar = commentObj.getString("user_avatar");
                        String content = commentObj.getString("content");

                        Comment comment = new Comment(content, username);
                        comments.add(comment);
                    }

                    // Thông báo cho Adapter biết là đã có thay đổi dữ liệu
                    runOnUiThread(() -> commentAdapter.notifyDataSetChanged());
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        });

        try {
            future.get();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
