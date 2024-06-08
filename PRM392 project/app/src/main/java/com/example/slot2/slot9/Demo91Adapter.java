package com.example.slot2.slot9;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.appcompat.view.menu.ActionMenuItemView;

import com.example.slot2.R;
import com.squareup.picasso.Picasso;

import java.util.List;

public class Demo91Adapter extends BaseAdapter {
   private Context context;
   private List<Product91>  mlist;

    public Demo91Adapter(Context context, List<Product91> mlist) {
        this.context = context;
        this.mlist = mlist;
    }

    @Override
    public int getCount() {
        return mlist.size();
    }

    @Override
    public Object getItem(int position) {
        return mlist.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder91 holder;

        if(convertView==null){
            convertView= LayoutInflater.from(context).inflate(R.layout.demo91_tiemview,parent,false);
            holder =new ViewHolder91();
            holder.imageView=convertView.findViewById(R.id.demo91_itemview_searchImage);
            holder.styleTv=convertView.findViewById(R.id.demo91_itemview_TvStyleid);
            holder.brandTv=convertView.findViewById(R.id.demo91_itemview_TvBrand);
            holder.priceTv=convertView.findViewById(R.id.demo91_itemview_TvPrice);
            holder.infoTv=convertView.findViewById(R.id.demo91_itemview_TvInfo);
            convertView.setTag(holder);
        }else {
            holder=(ViewHolder91) convertView.getTag();
        }
        Product91 product =mlist.get(position);
        if(product!=null){
            Picasso.get().load(product.getSearchImage()).into(holder.imageView);
            holder.styleTv.setText(product.getStyleId());
            holder.brandTv.setText(product.getBrand());
            holder.priceTv.setText(product.getPrice());
            holder.infoTv.setText(product.getInfo());
        }
        return convertView;
    }

    static class ViewHolder91{
        ImageView imageView;
        TextView styleTv,brandTv,priceTv,infoTv;
    }
}
