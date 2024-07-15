package com.example.myapplication;

import java.io.Serializable;

public class Comment implements Serializable {
    private String content;
    private String username;

    public Comment(String content, String username) {
        this.content = content;
        this.username = username;
    }

    public String getContent() {
        return content;
    }

    public String getUsername() {
        return username;
    }
}