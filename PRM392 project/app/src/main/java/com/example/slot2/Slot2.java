package com.example.slot2;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class Slot2 extends AppCompatActivity {

    EditText txt1,txt2;
    Button btn1;
    TextView tv1;
    @SuppressLint("MissingInflatedId")

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_slot2);

        txt1=findViewById(R.id.Edittxt1);
        txt2=findViewById(R.id.Edittxt2);
        btn1=findViewById(R.id.Butn1);
        tv1=findViewById(R.id.Textv1);
btn1.setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View v) {
            sumfn();
    }
});

    }
    void sumfn(){
        double a= Double.parseDouble(txt1.getText().toString());
        //get data of the input2
        double b=Double.parseDouble(txt2.getText().toString());
        //sum
        double s=a+b;
        //display result
        tv1.setText(String.valueOf(s));
    }
}