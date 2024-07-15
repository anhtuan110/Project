package com.example.myapplication;

import java.io.Serializable;

public class Question implements Serializable {
    private int id;
    private String username;
    private String avatar;
    private String question;

    private String password;
    private String name;

    private String userId;

    public Question(int id, String username, String avatar, String question, String password, String name, String userId) {
        this.id = id;
        this.username = username;
        this.avatar = avatar;
        this.question = question;
        this.password = password;
        this.name = name;
        this.userId = userId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Question(String username, String avatar, String question) {
        this.username = username;
        this.avatar = avatar;
        this.question = question;
    }


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getAvatar() {
        return avatar;
    }

    public void setAvatar(String avatar) {
        this.avatar = avatar;
    }

    public String getQuestion() {
        return question;
    }

    public void setQuestion(String question) {
        this.question = question;
    }
}
