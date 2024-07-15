package com.example.myapplication;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
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

public class UserActivity extends AppCompatActivity {
    private static final String TAG = "UserActivity";

    private Button buttonUser, buttonLogout, buttonAddQuestion;
    private EditText editTextSearch;
    private RecyclerView recyclerViewQuestions;

    private ArrayList<Question> questionList;
    private QuestionAdapter questionAdapter;
    private SharedPreferences sharedPreferences;
    private int loggedInUserId = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user);

        // Initialize UI components
        buttonUser = findViewById(R.id.buttonUser);
        buttonLogout = findViewById(R.id.buttonLogout);
        buttonAddQuestion = findViewById(R.id.buttonAddQuestion);
        editTextSearch = findViewById(R.id.editTextSearch);
        recyclerViewQuestions = findViewById(R.id.recyclerViewQuestions);

        // Setup RecyclerView
        recyclerViewQuestions.setLayoutManager(new LinearLayoutManager(this));
        questionList = new ArrayList<>();
        questionAdapter = new QuestionAdapter(this, questionList);
        recyclerViewQuestions.setAdapter(questionAdapter);

        // Initialize SharedPreferences for user login info
        sharedPreferences = getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
        loggedInUserId = sharedPreferences.getInt("id", -1);

        // Load questions when activity starts
        loadQuestions();

        // Button click listeners
        buttonUser.setOnClickListener(v -> {
            Intent intent = new Intent(UserActivity.this, MyselfActivity.class);
            startActivity(intent);
        });

        buttonLogout.setOnClickListener(v -> {
            Intent intent = new Intent(UserActivity.this, MainActivity.class);
            startActivity(intent);
            finish();
        });

        buttonAddQuestion.setOnClickListener(v -> {
            if (loggedInUserId == -1) {
                Toast.makeText(UserActivity.this, "Please login to add a question", Toast.LENGTH_SHORT).show();
            } else {
                showAddQuestionDialog();
            }
        });
    }

    private void loadQuestions() {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/api/questions");
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
                    questionList.clear();
                    JSONArray questionsArray = new JSONArray(response.toString());
                    for (int i = 0; i < questionsArray.length(); i++) {
                        JSONObject questionObj = questionsArray.getJSONObject(i);
                        String username = questionObj.getString("name");
                        String avatar = questionObj.getString("avatar");
                        String question = questionObj.getString("content");
                        String name = questionObj.getString("name");
                        String userId = questionObj.getString("user_id");
                        int id = questionObj.getInt("id");

                        Question q = new Question(id, username, avatar, question, "a", name, userId);
                        questionList.add(q);
                    }
                    Log.d(TAG, "JSON Parsing successful, questions loaded: " + questionList.size());

                    runOnUiThread(() -> questionAdapter.notifyDataSetChanged());
                } else {
                    Log.e(TAG, "HTTP error response code: " + responseCode);
                }
            } catch (Exception e) {
                Log.e(TAG, "Error loading questions: " + e.getMessage());
                e.printStackTrace();
            }
            return null;
        });

        try {
            future.get();
        } catch (Exception e) {
            Log.e(TAG, "Exception during future.get(): " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void showAddQuestionDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Add Question");

        View viewInflated = LayoutInflater.from(this).inflate(R.layout.dialog_add_question, (ViewGroup) findViewById(android.R.id.content), false);
        final EditText inputQuestion = viewInflated.findViewById(R.id.inputQuestion);

        builder.setView(viewInflated);

        builder.setPositiveButton(android.R.string.ok, (dialog, which) -> {
            dialog.dismiss();
            String questionContent = inputQuestion.getText().toString().trim();
            if (!questionContent.isEmpty()) {
                addQuestion(loggedInUserId, questionContent);
            } else {
                Toast.makeText(UserActivity.this, "Please enter a question", Toast.LENGTH_SHORT).show();
            }
        });

        builder.setNegativeButton(android.R.string.cancel, (dialog, which) -> dialog.cancel());

        builder.show();
    }

    private void addQuestion(int userId, String questionContents) {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/api/addQuestion");
                HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                conn.setRequestMethod("POST");
                conn.setRequestProperty("Content-Type", "application/json; charset=UTF-8");
                conn.setDoOutput(true);

                JSONObject jsonParam = new JSONObject();
                jsonParam.put("user_id", userId);
                jsonParam.put("question", questionContents);

                OutputStream os = conn.getOutputStream();
                os.write(jsonParam.toString().getBytes("UTF-8"));
                os.close();

                int responseCode = conn.getResponseCode();
                if (responseCode == HttpURLConnection.HTTP_OK) {
                    runOnUiThread(() -> {
                        Toast.makeText(UserActivity.this, "Question added successfully", Toast.LENGTH_SHORT).show();
                        loadQuestions(); // Reload questions after adding new question
                    });
                } else {
                    runOnUiThread(() -> Toast.makeText(UserActivity.this, "Failed to add question", Toast.LENGTH_SHORT).show());
                }
            } catch (Exception e) {
                Log.e(TAG, "Error adding question: " + e.getMessage());
                e.printStackTrace();
            }
            return null;
        });

        try {
            future.get();
        } catch (Exception e) {
            Log.e(TAG, "Exception during future.get() (addQuestion): " + e.getMessage());
            e.printStackTrace();
        }
    }
    @Override
    protected void onResume() {
        super.onResume();
        loadQuestions();
    }

}