using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study1 : MonoBehaviour
{
    // 자료형
    private int x; // 정수형 shot , long , double 
    private float y; // 실수형
    private string s; // 문장형
    private char c; // 문자형
    private bool b; // 참/거짓;


    // private : 내 클래스
    // public  : 타 클래스에서도 접근가능
    // protected : 자식 클래스에서만 접근 가능
    // abstract : 추상클래스 자식클래스 무조건 재정의를 필요로 할때 사용한다.
    // virtual  : 자식클래스 해당 함수를 추가적으로 정의할때 사용한다.

    // 조건문 : if - elseif = else 문  ,  Switch문 , 삼항연산자 (ex : int temp1 = x == 5 ? 2 : 3;
    // 삼항연산자 : ( 조건문 ) ? (참일때 리턴값) : (거짓일때 리턴값)
    // 반복문 : for , foreach

    // var 자료형은 항상 지역변수에서 선언을 하고 초기화도 해주어야한다.
    // 유니티에서는 쓰레드도 사용가능하지만 코루틴도 사용이 가능하다.

    // 자료구조 Array , List , Dictionary , Queue , Stack , HashTable

    //라면 4개 먹는다
    private int[] _arrays = new int[6]; // 4인분 냄비 정적
    private List<int> _lists = new List<int>(); // 2인분 냄비 동적
    private Dictionary<int, string> _dics = new Dictionary<int, string>(); // 2인분 냄비 동적 key = value

    private void Start()
    {
        for (int i = 0; i < _arrays.Length; i++)
        {
            _arrays[i] = 1 + i;
        }


        _lists.Add(1);
        _lists.Add(2);
        _lists.Add(3);
        _lists.Add(4);
        _lists.Add(5);
        _lists.Add(6);

        _dics.Add(0, "김동윤");
        _dics.Add(1, "김정인");

        Debug.Log(_arrays[3]); // 4
        Debug.Log(_lists[3]); // 4
        Debug.Log(_dics[1]); // 3
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
    }

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("*****");
        }
    }
}