﻿using System;

namespace HuaweiMobileServices.Base
{
    using HuaweiMobileServices.Utils;
    using UnityEngine;

    // Wrapper for com.huawei.hms.support.api.client.Status
    public sealed class Status : JavaObjectWrapper
    {
        private static readonly AndroidJavaClass NATIVE_BRIDGE = new AndroidJavaClass("org.m0skit0.android.hms.unity.base.StatusWrapper");

        private const string CLASS_NAME = "com.huawei.hms.support.api.client.Status";

        public static readonly Status SUCCESS = new Status(0);

        public static readonly Status FAILURE = new Status(1);

        public static readonly Status MESSAGE_NOT_FOUND = new Status(404);

        public static readonly Status CORE_EXCEPTION = new Status(500);

        private Action<int> mOnSuccessListener;

        public Status(AndroidJavaObject javaObject) : base(javaObject) { }

        private Status(int paramInt) : base(CLASS_NAME, paramInt, null) { }

        public bool HasResolution() => Call<bool>("hasResolution");

        public void StartResolutionForResult(Action<int> onSuccessListener, Action<Exception> onFailureListener)
        {
            mOnSuccessListener = onSuccessListener;
            NATIVE_BRIDGE.CallStatic("receiveStartResolutionForResult", AndroidContext.GetActivityContext(), JavaObject);
        }

        public int StatusCode
        {
            get => Call<int>("getStatusCode");
        }

        public string StatusMessage
        {
            get => CallAsString("getStatusMessage");
        }

        public AndroidPendingIntent Resolution
        {
            get => CallAsWrapper<AndroidPendingIntent>("getResolution");
        }

        public bool Success
        {
            get => Call<bool>("isSuccess");
        }

        public string ErrorString
        {
            get => CallAsString("getErrorString");
        }

        public bool Canceled
        {
            get => Call<bool>("isCanceled");
        }

        public bool Interrupted
        {
            get => Call<bool>("isInterrupted");
        }
    }

}