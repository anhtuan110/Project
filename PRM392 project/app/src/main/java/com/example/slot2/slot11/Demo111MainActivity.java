package com.example.slot2.slot11;

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

import com.example.slot2.R;
import com.google.gson.Gson;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class Demo111MainActivity extends AppCompatActivity {

    EditText txt1,txt2,txt3,txt0;
    TextView tv1;
    Button btnInsert,btnUpdate,btnDelete,btnSelect;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_demo111_main);
        txt0=findViewById(R.id.demo111Txt0);
        txt1=findViewById(R.id.demo111Txt1);
        txt2=findViewById(R.id.demo111Txt2);
        txt3=findViewById(R.id.demo111Txt3);
        tv1=findViewById(R.id.demo111TvResult);
        btnInsert=findViewById(R.id.demo111BtnInsert);
        btnDelete=findViewById(R.id.demo121BtnDelete);
        btnUpdate=findViewById(R.id.demo121BtnUpdate);
        btnSelect=findViewById(R.id.demo121BtnSelect);
        btnInsert.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                insertData();
            }
        });
        btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                deleteData();
            }
        });
        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateData();
            }
        });
        btnSelect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                selectData();
            }
        });

    }
    private List<PrdSelect> ls;
    String strReuslt;
    private void selectData(){
        Retrofit retrofit = new Retrofit.Builder().baseUrl("http://192.168.1.216/202406/").addConverterFactory(GsonConverterFactory.create()).build();
        InterfaceSelect select = retrofit.create(InterfaceSelect.class);
        Call<SrvResponseSelect>   call = select.getPrd();
       call.enqueue(new Callback<SrvResponseSelect>() {
           @Override
           public void onResponse(Call<SrvResponseSelect> call, Response<SrvResponseSelect> response) {
               SrvResponseSelect responseSelect = response.body();
               ls = new ArrayList<>(Arrays.asList(responseSelect.getProducts()));
               for (PrdSelect p:ls){
                    strReuslt += "Name: "+p.getName()+"Price :"+p.getPrice()+"Description"+ p.getDescription()+"\n";
               }
               tv1.setText(strReuslt);
           }

           @Override
           public void onFailure(Call<SrvResponseSelect> call, Throwable throwable) {
                tv1.setText(throwable.getMessage());
           }
       });
    }
    private void updateData(){
        PrdUpd p =new PrdUpd();
        p.setPid(txt0.getText().toString());
        p.setName(txt1.getText().toString());
        p.setPrice(txt2.getText().toString());
        p.setDescription(txt3.getText().toString());

        Retrofit retrofit = new Retrofit.Builder().baseUrl("http://192.168.1.216/202406/").addConverterFactory(GsonConverterFactory.create()).build();
        InterfaceUp up = retrofit.create(InterfaceUp.class);
        Call<SvrResponseUp> call = up.updateExe(p.getPid(),p.getName(),p.getPrice(),p.getDescription());
        call.enqueue(new Callback<SvrResponseUp>() {
            @Override
            public void onResponse(Call<SvrResponseUp> call, Response<SvrResponseUp> response) {
                SvrResponseUp responseUp = response.body();
                tv1.setText(responseUp.getMessage());
            }

            @Override
            public void onFailure(Call<SvrResponseUp> call, Throwable throwable) {
                tv1.setText(throwable.getMessage());
            }
        });
    }
    private void deleteData(){
        PrdDel p =new PrdDel();
        p.setPid(txt0.getText().toString());

        Retrofit retrofit = new Retrofit.Builder().baseUrl("http://192.168.1.216/202406/").addConverterFactory(GsonConverterFactory.create()).build();
        InterfaceDel del = retrofit.create(InterfaceDel.class);
        Call<SvrResponseDel> call = del.deleteExe(p.getPid());
        call.enqueue(new Callback<SvrResponseDel>() {
            @Override
            public void onResponse(Call<SvrResponseDel> call, Response<SvrResponseDel> response) {
                SvrResponseDel responseDel = response.body();
                tv1.setText(responseDel.getMessage());
            }

            @Override
            public void onFailure(Call<SvrResponseDel> call, Throwable throwable) {
                tv1.setText(throwable.getMessage());
            }
        });
    }
    private  void   insertData(){
        Prd prd =new Prd();
        prd.setName(txt1.getText().toString());
        prd.setPrice(txt2.getText().toString());
        prd.setDescription(txt3.getText().toString());

        Retrofit retrofit=new Retrofit.Builder().baseUrl("http://192.168.1.216/202406/").addConverterFactory(GsonConverterFactory.create()).build();
        InterfaceInsertPrd insertPrdObj = retrofit.create(InterfaceInsertPrd.class);
        Call<SvrResponsePrd> call=insertPrdObj.insertPrd(prd.getName(),prd.getPrice(),prd.getDescription());
        call.enqueue(new Callback<SvrResponsePrd>() {
            @Override
            public void onResponse(Call<SvrResponsePrd> call, Response<SvrResponsePrd> response) {
                SvrResponsePrd svrResponsePrd=response.body();
                tv1.setText(svrResponsePrd.getMessage() );
            }

            @Override
            public void onFailure(Call<SvrResponsePrd> call, Throwable t) {
                tv1.setText(t.getMessage());
            }
        });
    }
}