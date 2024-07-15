package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

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

public class UserActivity2 extends AppCompatActivity {
    private Button buttonUser, buttonLogout, buttonSearch, buttonAddQuestion;
    private EditText editTextSearch;
    private RecyclerView recyclerViewQuestions;

    private ArrayList<User> user;
    private AdminAdapter adminAdapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user2);

        buttonLogout = findViewById(R.id.buttonLogout);

        recyclerViewQuestions = findViewById(R.id.recyclerViewQuestions);

        recyclerViewQuestions.setLayoutManager(new LinearLayoutManager(this));
        user = new ArrayList<>();
        adminAdapter = new AdminAdapter(this, user);
        recyclerViewQuestions.setAdapter(adminAdapter);

        loadUser();
        buttonLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(UserActivity2.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });


    }

    private void loadUser() {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        Future<Void> future = executor.submit(() -> {
            try {
                URL url = new URL("http://10.33.25.24:3000/users");
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
                    for (int i = 0; i < questionsArray.length(); i++) {
                        JSONObject questionObj = questionsArray.getJSONObject(i);
                        String username = questionObj.getString("name");
                        String password = questionObj.getString("password");
                        String name = questionObj.getString("name");
                        int id = questionObj.getInt("id");

                        User q = new User(id,username,password,name);
                        user.add(q);
                    }


                    runOnUiThread(() -> adminAdapter.notifyDataSetChanged());
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