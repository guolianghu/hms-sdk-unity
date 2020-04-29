package org.m0skit0.android.hms.unity.activity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import androidx.annotation.Nullable;

import com.unity3d.player.UnityPlayer;

import org.m0skit0.android.hms.unity.BridgeType;
import org.m0skit0.android.hms.unity.auth.AuthBridge;
import org.m0skit0.android.hms.unity.base.StatusBridge;
import org.m0skit0.android.hms.unity.game.GameBridge;

public class NativeBridgeActivity extends Activity {

    private static final String TAG = NativeBridgeActivity.class.getSimpleName();

    public static final String TYPE = "TYPE";

    public static void start(final String type) {
        final Intent intent = new Intent(UnityPlayer.currentActivity, NativeBridgeActivity.class)
                .putExtra(TYPE, type);
        UnityPlayer.currentActivity.startActivity(intent);
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Log.d(TAG, "[HMS] onCreate");
        final Intent intent = getIntent();
        if (intent != null) {
            Log.d(TAG, "[HMS] onCreate getIntent " + intent);
            final String type = intent.getStringExtra(TYPE);
            if (type != null) {
                Log.d(TAG, "[HMS] onCreate type " + type);
                switch (type) {
                    case StatusBridge.STATUS:
                        Log.d(TAG, "[HMS] onCreate type StatusBridge.STATUS");
                        StatusBridge.launchStartResolutionForResult(this);
                        break;
                    case AuthBridge.AUTH:
                        Log.d(TAG, "[HMS] onCreate type AuthBridge.AUTH");
                        AuthBridge.launchStartSignIn(this);
                        break;
                    default:
                        Log.e(TAG, "Unknown type " + type);
                }
            }
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        Log.d(TAG, "[HMS] onActivityResult");
        super.onActivityResult(requestCode, resultCode, data);
        if (data != null) {
            switch (requestCode) {
                case BridgeType.STATUS:
                    StatusBridge.returnStartResolutionForResult(data);
                    break;
                case BridgeType.AUTH:
                    AuthBridge.returnStartSignIn(data);
                    break;
                case BridgeType.GAME:
                    GameBridge.returnShowAchievementList(data);
                default:
                    Log.e(TAG, "Unknown request code " + requestCode);
            }
        }
        finish();
    }
}
