package com.example.slot2.slot11;

import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.POST;

public interface InterfaceUp {
    @FormUrlEncoded
    @POST("update_post.php")
    Call<SvrResponseUp> updateExe(@Field("pid") String pid,@Field("name") String name, @Field("price") String price,@Field("description") String description);
}
