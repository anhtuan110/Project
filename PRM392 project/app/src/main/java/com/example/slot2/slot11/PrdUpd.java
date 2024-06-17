package com.example.slot2.slot11;

public class PrdUpd {
    private String name,price,description,pid;

    public PrdUpd(String name, String price, String description, String pid) {
        this.name = name;
        this.price = price;
        this.description = description;
        this.pid = pid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getPid() {
        return pid;
    }

    public void setPid(String pid) {
        this.pid = pid;
    }

    public PrdUpd() {
    }
}
