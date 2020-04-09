﻿namespace HuaweiMobileServices.IAP
{
    using HuaweiMobileServices.Utils;
    using UnityEngine;

    public class PurchaseIntentResult : JavaObjectWrapper
    {

        public PurchaseIntentResult(AndroidJavaObject javaObject) : base(javaObject) { }

        public virtual int ReturnCode
        {
            get => Call<int>("getReturnCode");
        }


        public virtual string ErrMsg
        {
            get => Call<AndroidJavaObject>("getErrMsg").AsString();
        }


        public virtual string PaymentData
        {
            get => Call<AndroidJavaObject>("getPaymentData").AsString();
        }


        public virtual string PaymentSignature
        {
            get => Call<AndroidJavaObject>("getPaymentSignature").AsString();
        }

    }

}