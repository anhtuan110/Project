package com.example.slot2.slot14;

import android.annotation.SuppressLint;
import android.content.Context;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;

public class Demo14MainActivity extends AppCompatActivity {
    Button btnSelect,btnInsert,btnUpdate,btnDelete;
    TextView textView;
    FnVolley fn;
    EditText txtName,txtPrice,txtDes,txtPid;
    Context context=this;
    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_demo14_main);
        btnSelect =findViewById(R.id.demo141btnGet);
        btnInsert=findViewById(R.id.demo141btnInsert);
        btnUpdate= findViewById(R.id.demo141btnUpdate);
        btnDelete=findViewById(R.id.demo141btnDelete);
        textView=findViewById(R.id.demo141TvResult);
        txtPid=findViewById(R.id.demo141TxtPid);
        txtName=findViewById(R.id.demo141TxtName);
        txtPrice=findViewById(R.id.demo141TxtPrice);
        txtDes=findViewById(R.id.demo141TxtDes);
        fn=new FnVolley();
        btnSelect.setOnClickListener(v -> {
            fn.getArrayObjects(context,textView);
        });
        btnInsert.setOnClickListener(v -> {
            fn.insertVolley(context,textView,txtName,txtPrice,txtDes);
        });
        btnUpdate.setOnClickListener(v -> {
            fn.updateVolley(context,textView,txtPid,txtName,txtPrice,txtDes);
        });
        btnDelete.setOnClickListener(v -> {
            fn.deleteVolley(context,textView,txtPid);
        });

    }
}