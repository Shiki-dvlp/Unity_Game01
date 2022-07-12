using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    public Transform target;
    private string playerTag = "Player";
    private bool isSearch = false;
    private bool isSearchEnter, isSearchStay, isSearchExit;

    void Update()
    {
        this.transform.position = target.position;
    }

    //接地判定を返すメソッド
    //物理判定の更新毎に呼ぶ必要がある
    public bool IsSearch()
    {
        if (isSearchEnter || isSearchStay)
        {
            isSearch = true;
        }
        else if (isSearchExit)
        {
            isSearch = false;
        }

        isSearchEnter = false;
        isSearchStay = false;
        isSearchExit = false;
        return isSearch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isSearchEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isSearchStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isSearchExit = true;
        }
    }
}
