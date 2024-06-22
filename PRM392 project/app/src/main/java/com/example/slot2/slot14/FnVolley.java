package com.example.slot2.slot14;

import android.content.Context;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.Nullable;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class FnVolley {
    String strJSON;
    public void getStringByVolley(Context context, TextView textView){

        RequestQueue queue = Volley.newRequestQueue(context);
        String url ="http://www.google.com/";
        StringRequest stringRequest=new StringRequest(Request.Method.GET, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String s) {
            textView.setText("KQ:" +s.substring(0,1000));
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                textView.setText(volleyError.getMessage());
            }
        });
        queue.add(stringRequest);
    }
    public void getArrayObjects(Context context,TextView textView){
        RequestQueue queue =Volley.newRequestQueue(context);
        String url ="https://hungnttg.github.io/array_json_new.json";
        JsonArrayRequest request = new JsonArrayRequest(url, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray jsonArray) {
                for(int i=0;i<jsonArray.length();i++){
                    try{
                        JSONObject person =jsonArray.getJSONObject(i);
                        String id =person.getString("id");
                        String name = person.getString("name");
                        String email =person.getString("email");

                        JSONObject phone =person.getJSONObject("phone");
                        String mobile=phone.getString("mobile");
                        String home =phone.getString("home");

                        strJSON +="ID"+id+"\n";
                        strJSON +="Name"+name+"\n";
                        strJSON +="Email"+email+"\n";
                        strJSON +="Mobile"+mobile+"\n";
                        strJSON +="Home"+home+"\n";

                    } catch (JSONException e) {
                        throw new RuntimeException(e);
                    }
                }
                textView.setText(strJSON);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                textView.setText(volleyError.getMessage());
            }
        });
        queue.add(request);
    }
    public  void insertVolley(Context context,TextView tvResult,TextView tvName,TextView tvPrice,TextView tvDes){
        RequestQueue queue =Volley.newRequestQueue(context);
        String url ="http://192.168.1.216/202406/create_product.php";
        StringRequest stringRequest =new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String s) {
                tvResult.setText(s.toString());
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                tvResult.setText(volleyError.getMessage());
            }
        })
        {
            @Nullable
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> myData= new HashMap<>();
                myData.put("name",tvName.getText().toString());
                myData.put("price",tvPrice.getText().toString());
                myData.put("Description",tvDes.getText().toString());
                return myData;
            }
        };
        queue.add(stringRequest);
    }
    public  void updateVolley(Context context, TextView tvResult, EditText tvPid, EditText tvName, EditText tvPrice, EditText    tvDes){
        RequestQueue queue =Volley.newRequestQueue(context);
        String url ="http://192.168.1.216/202406/update_product.php";
        StringRequest stringRequest =new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String s) {
                tvResult.setText(s.toString());
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                tvResult.setText(volleyError.getMessage());
            }
        })
        {
            @Nullable
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> myData= new HashMap<>();
                myData.put("pid",tvPid.getText().toString());
                myData.put("name",tvName.getText().toString());
                myData.put("price",tvPrice.getText().toString());
                myData.put("Description",tvDes.getText().toString());
                return myData;
            }
        };
        queue.add(stringRequest);
    }
    public  void deleteVolley(Context context, TextView tvResult, EditText tvPid){
        RequestQueue queue =Volley.newRequestQueue(context);
        String url ="http://192.168.1.216/202406/delete_product.php";
        StringRequest stringRequest =new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
            @Override
            public void onResponse(String s) {
                tvResult.setText(s.toString());
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                tvResult.setText(volleyError.getMessage());
            }
        })
        {
            @Nullable
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> myData= new HashMap<>();
                myData.put("pid",tvPid.getText().toString());

                return myData;
            }
        };
        queue.add(stringRequest);
    }
}
