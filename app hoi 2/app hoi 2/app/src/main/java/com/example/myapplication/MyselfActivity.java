package com.example.myapplication;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;

public class MyselfActivity extends AppCompatActivity {
    private SharedPreferences sharedPreferences;
    private int loggedInUserId = -1;
    private ArrayList<Question> questionList;
    private RecyclerView recyclerViewQuestions;
    private MyselfAdapter questionAdapter;
    private Button buttonUser, buttonLogout;
    private static final String TAG = "MainActivity";
    private ImageButton btnBack;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_myself);
        btnBack = findViewById(R.id.btnBacks);
        btnBack.setOnClickListener(v -> onBackPressed());

        recyclerViewQuestions = findViewById(R.id.recyclerViewQuestionss);
        buttonUser = findViewById(R.id.buttonUser);
        buttonLogout = findViewById(R.id.buttonLogout);
        recyclerViewQuestions.setLayoutManager(new LinearLayoutManager(this));
        questionList = new ArrayList<>();
        questionAdapter = new MyselfAdapter(this, questionList);
        recyclerViewQuestions.setAdapter(questionAdapter);
        sharedPreferences = getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
        loggedInUserId = sharedPreferences.getInt("id", -1);
        fetchQuestionsByUserId(loggedInUserId);

        buttonUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MyselfActivity.this, MyselfActivity.class);
                startActivity(intent);            }
        });

        buttonLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(MyselfActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }


    private void fetchQuestionsByUserId(int userId) {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/questions/" + userId); // Thay đổi thành địa chỉ IP của bạn
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

                    JSONArray questionsArray = new JSONArray(response.toString());
                    questionList.clear(); // Clear existing data
                    for (int i = 0; i < questionsArray.length(); i++) {
                        JSONObject questionObj = questionsArray.getJSONObject(i);
                        int id = questionObj.getInt("id");
                        String username = questionObj.getString("user_id");
                        String avatar = questionObj.getString("user_id");
                        String content = questionObj.getString("content");
                        String pass = questionObj.getString("user_id");
                        String name = questionObj.getString("user_id");
                        String userIdString = questionObj.getString("user_id");

                        Question q = new Question(id, username, avatar, content,pass,name, userIdString);
                        questionList.add(q);
                    }
                    Log.e(TAG, "HTTP error code: " + questionList);

                    runOnUiThread(() -> questionAdapter.notifyDataSetChanged());
                } else {
                    Log.e(TAG, "HTTP error code: " + responseCode);
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
