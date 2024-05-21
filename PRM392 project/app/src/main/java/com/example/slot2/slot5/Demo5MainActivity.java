package com.example.slot2.slot5;

import android.annotation.SuppressLint;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;

import java.util.ArrayList;
import java.util.List;

public class Demo5MainActivity extends AppCompatActivity {
    ListView listView;
    Demo51Adapter adapter;
    List<Demo51Product> list =new ArrayList<>();
    @SuppressLint("MissingInflatedID")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_demo5_main);
        listView=findViewById(R.id.demo51Listview1);
        /*Demo51SqliteHelpper helper=new Demo51SqliteHelpper(this);
        SQLiteDatabase db = helper.getReadableDatabase();*/
        Demo51ProductDAO dao =new  Demo51ProductDAO(this);
        /*Demo51Product p=new Demo51Product("4","Sanpham4",123,1);*/
        list =dao.getAll();
        adapter =new Demo51Adapter(list,this);
        /*int kq =dao.insertProduct(p);*/

        listView.setAdapter(adapter);
    }
}