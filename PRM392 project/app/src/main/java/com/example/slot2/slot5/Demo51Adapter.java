package com.example.slot2.slot5;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.slot2.R;

import java.util.ArrayList;
import java.util.List;

public class Demo51Adapter extends BaseAdapter {
    private List<Demo51Product> mList;
    private Context mContext;

    public Demo51Adapter(List<Demo51Product> mList, Context mContext) {
        this.mList = mList;
        this.mContext = mContext;
    }

    @Override
    public int getCount() {
        return 0;
    }

    @Override
    public Object getItem(int position) {
        return mList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        Demo51ViewHolder holder;
        if(convertView == null){
            convertView = LayoutInflater.from(mContext).inflate(R.layout.demo51_item_view,parent,false);
            holder =new Demo51ViewHolder();
            holder.img=convertView.findViewById(R.id.demo51_itemview_img);
            holder.tvId=convertView.findViewById(R.id.demo51_itemview_tvID);
            holder.tvName=convertView.findViewById(R.id.demo51_itemview_tvName);
            holder.tvPrice=convertView.findViewById(R.id.demo51_itemview_tvPrice);
            convertView.setTag(holder);
        }else {
            holder=(Demo51ViewHolder)  convertView.getTag();
        }
        Demo51Product product =mList.get(position);
        if(product!= null){
            holder.img.setImageResource(R.drawable.apple);
            holder.tvId.setText(product.getId());
            holder.tvName.setText(product.getName());
            holder.tvPrice.setText(String.valueOf(product.getPrice()));
        }
        return convertView;
    }

    static class  Demo51ViewHolder {
     ImageView img;
     TextView tvId,tvName,tvPrice;
    }
}
