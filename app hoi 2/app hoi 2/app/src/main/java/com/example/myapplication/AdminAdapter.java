package com.example.myapplication;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Handler;
import android.os.Looper;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONObject;

import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class AdminAdapter extends RecyclerView.Adapter<AdminAdapter.QuestionViewHolder> {
    private Context context;
    private ArrayList<User> user;

    public AdminAdapter(Context context, ArrayList<User> user) {
        this.context = context;
        this.user = user;
    }

    @NonNull
    @Override
    public QuestionViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_questions, parent, false);
        return new QuestionViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull QuestionViewHolder holder, int position) {
        User user1 = user.get(position);
        holder.textViewUsername.setText(user1.getName());

        holder.buttonUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showUpdateDialog(user1);
            }
        });

        holder.buttonDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                user.remove(position);
                notifyItemRemoved(position);
                notifyItemRangeChanged(position, user.size());

                ExecutorService executor = Executors.newSingleThreadExecutor();
                executor.execute(new Runnable() {
                    @Override
                    public void run() {
                        try {
                            URL url = new URL("http://192.168.1.216:3000/users/" + user1.getId());
                            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                            conn.setRequestMethod("DELETE");
                            conn.setRequestProperty("Content-Type", "application/json; charset=UTF-8");

                            int responseCode = conn.getResponseCode();
                            if (responseCode == HttpURLConnection.HTTP_OK) {
                                new Handler(Looper.getMainLooper()).post(new Runnable() {
                                    @Override
                                    public void run() {
                                        Toast.makeText(context, "Deleted successfully", Toast.LENGTH_SHORT).show();
                                    }
                                });
                            } else {
                                new Handler(Looper.getMainLooper()).post(new Runnable() {
                                    @Override
                                    public void run() {
                                        Toast.makeText(context, "Failed to delete question", Toast.LENGTH_SHORT).show();
                                    }
                                });
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });

                Toast.makeText(context, "Deleted item at position " + position, Toast.LENGTH_SHORT).show();
            }
        });
    }


    private void showUpdateDialog(User user) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setTitle("Update User Information");

        // Set up the input
        LinearLayout layout = new LinearLayout(context);
        layout.setOrientation(LinearLayout.VERTICAL);


        EditText editTextUsername = new EditText(context);
        editTextUsername.setHint("Enter username");
        editTextUsername.setInputType(InputType.TYPE_CLASS_TEXT);

        layout.addView(editTextUsername);


        EditText editTextPassword = new EditText(context);
        editTextPassword.setHint("Enter password");
        editTextPassword.setInputType(InputType.TYPE_CLASS_TEXT | InputType.TYPE_TEXT_VARIATION_PASSWORD);
        layout.addView(editTextPassword);

        builder.setView(layout);

        builder.setPositiveButton("Update", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String username = editTextUsername.getText().toString().trim();
                String password = editTextPassword.getText().toString().trim();


                user.setUsername(username);
                user.setPassword(password);


                updateQuestionOnServer(user);


                notifyDataSetChanged();

                dialog.dismiss();

                Toast.makeText(context, "Updated user information", Toast.LENGTH_SHORT).show();
            }
        });

        builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        // Show dialog
        builder.show();
    }

    private void updateQuestionOnServer(User user) {
        ExecutorService executor = Executors.newSingleThreadExecutor();
        executor.execute(new Runnable() {
            @Override
            public void run() {
                try {
                    URL url = new URL("http://10.33.25.24:3000/users/" + user.getId());
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("PUT");
                    conn.setRequestProperty("Content-Type", "application/json; charset=UTF-8");
                    conn.setDoOutput(true);

                    JSONObject jsonParam = new JSONObject();
                    jsonParam.put("username", user.getUsername());
                    jsonParam.put("password", user.getPassword());

                    OutputStream os = conn.getOutputStream();
                    os.write(jsonParam.toString().getBytes("UTF-8"));
                    os.close();

                    int responseCode = conn.getResponseCode();
                    if (responseCode == HttpURLConnection.HTTP_OK) {
                        new Handler(Looper.getMainLooper()).post(new Runnable() {
                            @Override
                            public void run() {
                                Toast.makeText(context, "Question updated successfully", Toast.LENGTH_SHORT).show();
                            }
                        });
                    } else {
                        new Handler(Looper.getMainLooper()).post(new Runnable() {
                            @Override
                            public void run() {
                                Toast.makeText(context, "Failed to update question", Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return user.size();
    }

    public static class QuestionViewHolder extends RecyclerView.ViewHolder {
        ImageView imageViewAvatar;
        TextView textViewUsername, textViewQuestion;
        Button buttonComment;
        Button buttonUpdate, buttonDelete;

        public QuestionViewHolder(@NonNull View itemView) {
            super(itemView);
            imageViewAvatar = itemView.findViewById(R.id.imageViewAvatars);
            textViewUsername = itemView.findViewById(R.id.textViewUsernames);
            buttonUpdate = itemView.findViewById(R.id.buttonUpdate);
            buttonDelete = itemView.findViewById(R.id.buttonDelete);
        }
    }
}
