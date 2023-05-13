using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject PlayerView;
    [SerializeField]
    List<int> playerLevels;
    [SerializeField]
    List<double> playerPower;
    TcpListener listener;
    TcpClient Resp;
    Socket soc;
    Stream stream;
    StreamReader reader;
    // Start is called before the first frame update
    void Start()
    {
        listener = new TcpListener(3245);
        PlayerView.SetActive(false);
        Debug.Log("waiting");
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(reader.ReadLine());
    }
    public void LoadCharaButton(){
        UnityWhy();
        return;
    }
    public async void UnityWhy(){
            await Task.Run(() =>{
            bool connecting = true;
            listener.Start(10);
            Debug.Log("Test");
            soc = listener.AcceptSocket();
            stream = new NetworkStream(soc);
            reader = new StreamReader(stream);
            byte[] buffer = new byte[256];
            for (int i = 0; i < this.playerLevels.Count; i++)
            {   
                int test = reader.Read();
                while(test == -1){
                    test = reader.Read();
                }
                this.playerLevels[i] = test;
            }
            int ready = 0;
            for (int i = 0; i <  this.playerPower.Count; i++)
            {
                int test = reader.Read();
                int output = 0;
                Debug.Log(test);
                this.playerPower[i] = test;
                ready = 0;
            }
            });
            Player.GetComponent<actor>().setCharacter("Test",this.playerLevels,this.playerPower);
            
    }

    public void StartGame(){
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Player);
        SceneManager.LoadScene("DebugScene");
        PlayerView.SetActive(true);
    }
}
