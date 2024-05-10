package com.example.slot2;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class Slot21 extends AppCompatActivity {

   EditText txt1,txt2;
   Button btn1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_slot21);
        txt1=findViewById(R.id.slot21txt1);
        txt2=findViewById(R.id.slot21txt2);
        btn1=findViewById(R.id.slot21btn1);
        btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(Slot21.this, Slot22.class);
                //put date to intent
                i.putExtra("a", txt1.getText().toString());
                i.putExtra("b", txt2.getText().toString());
                //start
                startActivity(i);
            }
        });

    }
}