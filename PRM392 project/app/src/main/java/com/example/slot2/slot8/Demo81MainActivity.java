package com.example.slot2.slot8;

import android.graphics.Typeface;
import android.os.Bundle;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;

public class Demo81MainActivity extends AppCompatActivity {

    TextView tv1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_demo81_main2);
    tv1 =findViewById(R.id.demo81Tv1);
        Typeface font =Typeface.createFromAsset(getAssets(),"Blazed.ttf");
        tv1.setTypeface(font );
    }
}