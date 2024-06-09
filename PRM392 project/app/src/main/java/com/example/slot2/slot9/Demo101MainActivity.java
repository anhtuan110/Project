package com.example.slot2.slot9;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.slot2.R;
import com.squareup.picasso.Picasso;

public class Demo101MainActivity extends AppCompatActivity {

    private TextView tvStyleId,tvBrand,tvPrice,tvInfo;
    private ImageView img;
    Intent intent;
    Product91 product;
    Demo10CartManager cartManager;
    Button btn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_demo101_main);
        img=findViewById(R.id.demo101ImageView1);
        tvStyleId=findViewById(R.id.demo101TvStyleID);
        tvBrand=findViewById(R.id.demo101TvBrand);
        tvPrice=findViewById(R.id.demo101TvPrice);
        tvInfo=findViewById(R.id.demo101TvInfo);
        btn =findViewById(R.id.demo101_btnAddToCard);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addToCartClicked();
            }
        });
        cartManager= Demo10CartManager.getInstance();
        intent= getIntent();
        product=intent.getParcelableExtra("PRODUCT");
        if(product!= null){
            Picasso.get().load(product.getSearchImage()).into(img);
            tvStyleId.setText(product.getStyleId());
            tvBrand.setText(product.getBrand());
            tvPrice.setText(product.getPrice());
            tvInfo.setText(product.getInfo());
        }

    }

    private void addToCartClicked() {
        Intent intent1 =getIntent();
        Product91 product1=intent1.getParcelableExtra("PRODUCT");
        if(product1!= null){
            cartManager.addProductToCart(product1);
            Intent intent2= new Intent(this,Demo101CartMainActivity.class);
            startActivity(intent2);
        }
    }
}