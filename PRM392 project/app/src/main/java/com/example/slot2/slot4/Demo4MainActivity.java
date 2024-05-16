package com.example.slot2.slot4;

import android.os.Bundle;
import android.widget.ListView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;

import java.util.ArrayList;

public class Demo4MainActivity extends AppCompatActivity {

    ListView lv;
    Demo4Adapter adapter;
    ArrayList<Demo4Contact> ls = new ArrayList<>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_demo4_main2);
        lv =findViewById(R.id.demo4);
        ls.add(new Demo4Contact("Nguyen Van A","19",R.drawable.apple));
        ls.add(new Demo4Contact("Nguyen Van B","16",R.drawable.blogger));
        ls.add(new Demo4Contact("Nguyen Van C","15",R.drawable.hp));
        ls.add(new Demo4Contact("Nguyen Van D","20",R.drawable.chrome));
        ls.add(new Demo4Contact("Nguyen Van E","18",R.drawable.apple));
        adapter =new Demo4Adapter(ls,this);
        lv.setAdapter(adapter);

    }
}