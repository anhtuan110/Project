package com.example.slot2.slot9;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.widget.ListView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;

import java.util.List;

public class Demo101CartMainActivity extends AppCompatActivity {
    private ListView listView;
    private Demo101CartAdapter adapter;
    Demo10CartManager cartManager;
    List<Product91> cartItem;
    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_demo101_cart_main);
        listView =findViewById(R.id.demo101_cartActivity);
        cartManager=Demo10CartManager.getInstance();
        cartItem =cartManager.getCartItems();
        adapter=new Demo101CartAdapter(this,cartItem);
        listView.setAdapter(adapter);

    }
}