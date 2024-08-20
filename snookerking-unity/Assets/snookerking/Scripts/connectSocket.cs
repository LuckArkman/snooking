using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;

public class NewBehaviourScript : MonoBehaviour
{
    private SocketIOUnity socket;
    private string code;

    void Start()
    {
        // socket = new SocketIOUnity("http://localhost:5000");

        // socket.OnConnected += (render, e) =>
        // {
        //     Debug.Log("Connected");
        //     AddCode();
        //     pushGame(code, "machine");
        // };
        // socket.Connect();
    }

    private void AddCode()
    {
        // code = Guid.NewGuid().ToString();
        // socket.Emit("code_user", new { code = code });
    }
    private void PushEvent(string message)
    {
        // socket.Emit("user_activity", new { message = message });
    }
    private void pushGame(string id_code, string adversary_code)
    {
        // socket.Emit("add_game", new { id_code = id_code, adversary_code = adversary_code });
    }
}
