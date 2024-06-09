package com.example.slot2.slot9;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.slot2.R;

import java.util.List;

public class Demo101CartAdapter extends ArrayAdapter<Product91> {
    private Context mContext;
    public Demo101CartAdapter(@NonNull Context context, @NonNull List<Product91> product) {
        super(context, 0, product);
        mContext=context;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        View listItem=convertView;
        if(listItem==null){
            listItem= LayoutInflater.from(mContext).inflate(R.layout.demo101_cart_item,parent,false);
        }
        Product91 currentProduct=getItem(position);
        TextView productName=listItem.findViewById(R.id.demo101_cartItem_tvProductName);
        productName.setText(currentProduct.getStyleId());
        TextView productQuatity= listItem.findViewById(R.id.demo101_cartItem_tvProductQuatity);
        productQuatity.setText("Quantity"+1);

        return listItem;

    }
}
