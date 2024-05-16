package com.example.slot2.slot4;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.slot2.R;

import java.util.ArrayList;

public class Demo4Adapter extends BaseAdapter {

    private ArrayList<Demo4Contact> ls;
    private Context context;

    public Demo4Adapter(ArrayList<Demo4Contact> ls, Context context) {
        this.ls = ls;
        this.context = context;
    }

    @Override
    public int getCount() {
        return ls.size();
    }

    @Override
    public Object getItem(int position) {
        return ls.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewDT vax;
        if(convertView==null){
            vax =new ViewDT();
            convertView= LayoutInflater.from(context).inflate(R.layout.demo41_item_view,parent,false);
            vax.img_hinh=convertView.findViewById(R.id.demo4ItemHinh);
            vax.tv_ten=convertView.findViewById(R.id.demo4ItemTen);
            vax.tv_tuoi=convertView.findViewById(R.id.demo4ItemTuoi);
            convertView.setTag(vax);
        }else {
            vax =(ViewDT) convertView.getTag();

        }
        vax.img_hinh.setImageResource(ls.get(position).getHinh());
        vax.tv_ten.setText(ls.get(position).getTen());
        vax.tv_tuoi.setText(ls.get(position).getTuoi());
        return convertView;
    }
    class ViewDT {
        ImageView img_hinh;
        TextView tv_ten,tv_tuoi;
    }
}
