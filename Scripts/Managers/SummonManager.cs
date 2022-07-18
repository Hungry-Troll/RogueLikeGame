﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public class SummonManager
{
    //아이템 등급 구분용
    public ItemGrade _itemGrade = ItemGrade.NoArti;

    //아이템 리스트
    public ItemList _itemList = ItemList.None;

    public void Init()
    {
        //플레이어 스텟처럼 지금의 데이터를 가지고 와서 저장할
        //스텟 스크립트를 만들어야 함
        //그다음에 게임매니저에 연결을 해야 되는대
        //데이터 다음으로 연결을 해 놔야 에러가 안생김

        //= GameManager.Data.axeStatDict;
    }

    public void MonsterCreat()
    {
        MapManager.SumPos sumPos = new MapManager.SumPos();

        for (int i = 0; i < 5; i++)
        {
            GameObject Slim = GameManager.Resouce.Instantiate("Creature/Ork");
            Slim.name = $"Ork_{i}";

            GameManager.Map._mapControll = MapControll.SumMonster;
            sumPos = GameManager.Map.CanSum();
            //int X = arr[0];
            //int Y = arr[1];

            Vector3Int pos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            MonsterController mc = Slim.GetComponent<MonsterController>();
            mc.CellPos = pos;

            GameManager.Obj.Add(Slim);
        }
    }

    public void PlayerCreat()
    {
        MapManager.SumPos sumPos = new MapManager.SumPos();

        GameObject player = GameManager.Resouce.Instantiate("Creature/Player");
        player.name = "Player";
        GameManager.Obj.Add(player);

        GameManager.Map._mapControll = MapControll.SumPlayerStairUp;
        sumPos = GameManager.Map.CanSum();
        //int X = arr[0];
        //int Y = arr[1];
        Vector3Int playerPos = new Vector3Int()
        {
            x = sumPos.x,
            y = sumPos.y
        };

        PlayerController pc = player.GetComponent<PlayerController>();
        pc.CellPos = playerPos;

    }


    public void ItemCreate()
    {
        Dictionary<string, ItemTable> _ItemTable;
        Dictionary<int, ItemStat> _StatDict; // 아이템용 스텟 딕
        Dictionary<int, PotionStat> _PotionStatDic; // 포션용 스텟 딕
        PotionStat _potionStat; // 포션용
        string _itemName = null;

        #region NextCoding
        switch (_itemList)
        {
            //추후 실제 적용 코드임

            //case ItemList.Axe:
            //    _itemName = "axe";
            //    _ItemTable = GameManager.Data.axe_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.axe_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.axeStatDict;
            //    break;

            //case ItemList.Boot:
            //    _itemName = "boot";
            //    _ItemTable = GameManager.Data.boot_TableDict;
            //    _StatDict = GameManager.Data.bootStatDict;
            //    break;

            //case ItemList.Bow:
            //    _itemName = "Bow";
            //    _ItemTable = GameManager.Data.bow_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.bow_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.bowStatDict;
            //    break;

            //case ItemList.Glove:
            //    _itemName = "glove";
            //    _ItemTable = GameManager.Data.glove_TableDict;
            //    _StatDict = GameManager.Data.gloveStatDict;
            //    break;

            //case ItemList.Helmet:
            //    _itemName = "helmet";
            //    _ItemTable = GameManager.Data.helmet_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.helmet_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.helmetStatDict;
            //    break;

            //case ItemList.Mace:
            //    _itemName = "mace";
            //    _ItemTable = GameManager.Data.mace_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.mace_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.maceStatDict;
            //    break;

            //case ItemList.Ring:
            //    _itemName = "ring";
            //    _ItemTable = GameManager.Data.ring_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.ring_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.ringStatDict;
            //    break;

            //case ItemList.Robe:
            //    _itemName = "Robe";
            //    _ItemTable = GameManager.Data.robe_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.robe_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.robeStatDict;
            //    break;

            //case ItemList.Shield:
            //    _itemName = "shield";
            //    _ItemTable = GameManager.Data.shield_TableDict;
            //    _StatDict = GameManager.Data.shieldStatDict;
            //    break;

            //case ItemList.Spear:
            //    _itemName = "spear";
            //    _ItemTable = GameManager.Data.spear_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.spear_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.spearStatDict;
            //    break;

            //case ItemList.Staff:
            //    _itemName = "staff";
            //    _ItemTable = GameManager.Data.staff_TableDict;
            //    _StatDict = GameManager.Data.staffStatDict;
            //    break;

            //case ItemList.Sword:
            //    _itemName = "sword";
            //    _ItemTable = GameManager.Data.sword_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.sword_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.swordStatDict;
            //    break;

            //case ItemList.Amulet:
            //    _itemName = "amulet";
            //    _ItemTable = GameManager.Data.amulet_TableDict;
            //    if (_itemGrade == ItemGrade.RanArti)
            //        _StatDict = GameManager.Data.amulet_randartStatDict;
            //    else
            //        _StatDict = GameManager.Data.amuletStatDict;
            //    break;  

            case ItemList.Potion:
                _itemName = "potion";
                _potionStat = new PotionStat();
                _ItemTable = GameManager.Data.potion_TableDict;
                _PotionStatDic = GameManager.Data.potionStatDict;
                break;
        }

        ///////////////////////////////////////////
        ///나중에 쓸 코드
        /// ItemStat _itemStat = new ItemStat();
        // GameObject item = ItemCraateEx(_itemStat, _ItemTable, _StatDict, str);

        #endregion


        #region ItemCreateEx
        _itemGrade = ItemGrade.NoArti;
        //_itemGrade = ItemGrade.RanArti;
        //_itemGrade = ItemGrade.FickArti;

        ItemStat _itemStat = new ItemStat();
        _ItemTable = GameManager.Data.axe_TableDict;
        _StatDict = GameManager.Data.axeStatDict;
        _itemName = "axe";

        //아이템 생성 함수
        ItemCreateEx(_itemStat, _ItemTable, _StatDict, _itemName);
        #endregion

        // 포션 생성 함수
        _itemGrade = ItemGrade.FickArti;
        _potionStat = new PotionStat();
        _ItemTable = GameManager.Data.potion_TableDict;
        _PotionStatDic = GameManager.Data.potionStatDict;
        _itemName = "potion";


        if (_itemName == "potion")
        {
            PotionCreateEx(_potionStat, _ItemTable, _PotionStatDic, _itemName);
        }
        else if (_itemName == "scroll")
        {
            //ScrollCreateEx()
        }
        else
        {
            ItemCreateEx(_itemStat, _ItemTable, _StatDict, _itemName);
        }
        

        // 매직 생성 함수
    }


    public void ItemPool()
    {
        //소모성 아이템 장착 아이템 계산 추후 확률을 바꿔야 될거 같음
        //아이템 셀렉에서 어떤 종류의 아이템 까지 결정됨
        ItemSelect();
        //아이템 등급을 결정
        ItemGradeCal();


        //아이템 소모품 확률을 어느정도로 할지 생각해야됨 지금은 대충 50%?? 정도 구상
        //플레이어 스킬레벨에 따른 아이템 드랍율도 생각해야됨

        //당장은 장비 구현만 우선 해보고 장비 능력치 잘 들어가는지 체크 해볼 것
        //구현만 하고 테스트는 모든 장비를 다 하나씩 불러와서 해야됨 그때는 아이템 풀로 하지말고 하드코딩
        //특히 랜다트 쪽은 버그가 날 수 있음 주의

        // 확률에 따라서 노멀 // 랜다트 // 픽다트 나옴


    }
    public void ItemSelect()
    {
        int itemCheck = Random.Range(0, 10);
        if (itemCheck <= 5)
            ItemComsum();
        else
            ItemEquip();
    }
    public void ItemComsum()
    {
        int itemRan = Random.Range(0, 100);
        if (itemRan <= 39)
            _itemList = ItemList.Potion;
        if (itemRan > 40 && itemRan <= 69)
            _itemList = ItemList.Scroll;
        else
            _itemList = ItemList.Magic;

    }
    public void ItemEquip()
    {
        int itemRan = Random.Range(0, 12);
        switch (itemRan)
        {
            case 0: _itemList = ItemList.Axe; break;
            case 1: _itemList = ItemList.Boot; break;
            case 2: _itemList = ItemList.Bow; break;
            case 3: _itemList = ItemList.Glove; break;
            case 4: _itemList = ItemList.Helmet; break;
            case 5: _itemList = ItemList.Mace; break;
            case 6: _itemList = ItemList.Ring; break;
            case 7: _itemList = ItemList.Robe; break;
            case 8: _itemList = ItemList.Shield; break;
            case 9: _itemList = ItemList.Spear; break;
            case 10: _itemList = ItemList.Staff; break;
            case 11: _itemList = ItemList.Sword; break;
                //case 20: _itemList = Define.ItemList.None; break;
        }
    }
    public void ItemGradeCal()
    {
        int ran = Random.Range(1, 101);
        if (ran <= 5)
            _itemGrade = ItemGrade.FickArti;
        else if (ran <= 15)
            _itemGrade = ItemGrade.RanArti;
        else
            _itemGrade = ItemGrade.NoArti;
    }
    #region itemCreate
    //TableDict = axeTableDict, StatDict = axe
    //기존 딕셔너리로 클래스를 일일히 함수로 만들지 않고 부모클래스로 통합함
    public void ItemCreateEx(ItemStat _itemStat, Dictionary<string, ItemTable> TableDict, Dictionary<int, ItemStat> StatDict, string itemName)
    {
        ItemTable _itemTableDict = null;
        switch(_itemGrade)
        {
            case ItemGrade.NoArti:
                _itemTableDict = TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                _itemTableDict = TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                _itemTableDict = TableDict["FirckArti"];
                break;
        }

        int startNum = _itemTableDict._startNum; //딕 시작값
        int endNum = _itemTableDict._endNum; //딕 끝값
        //int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int starttemp = 0; //링 아뮬렛 아이템 닉네임 찾는 용도 0으로 한 이유는 if 문 돌리려고
        int endtemp = 0; // 링 아뮬렛 아이템 닉네임 찾는 용도
        if (itemName == "ring" || itemName == "amulet")
        {
            ItemTable _itemTableRandartDict = null;
            switch (_itemGrade)
            {
                case ItemGrade.NoArti:
                    _itemTableRandartDict = TableDict["NoArti_Icon"];
                    starttemp = _itemTableRandartDict._startNum; //일단 아뮬렛은 확인함 링 따로 확인 해야 됨
                    endtemp = _itemTableRandartDict._endNum;
                    break;
                case ItemGrade.RanArti:
                    _itemTableRandartDict = TableDict["RanArti_Icon"];
                    starttemp = _itemTableRandartDict._startNum; //일단 아뮬렛은 확인함 링 따로 확인 해야 됨
                    endtemp = _itemTableRandartDict._endNum;
                    break;
                case ItemGrade.FickArti:
                    //_itemTableRandartDict = TableDict["FirckArti"]; //일단 아뮬렛은 확인함 링 따로 확인 해야 됨
                    break;
            }
            // 랜덤 아이콘 추출용 변수가 필요함 
            //int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용
        }


        for (int i = startNum; i < endNum+1; i++)
        {
            string nickName; //리턴용
            ItemStat itemNum = StatDict[i];// 나중에 random으로 수정
            nickName = itemNum._NickName;

            // 링, 아뮬렛 전용 코드 아이템 아이콘을 가지고 오는 코드
            if (starttemp != 0)
            {
                nickName = StatDict[starttemp]._NickName;
                if (starttemp < endtemp)// 테스트용 코드
                starttemp++;// 테스트용 코드
            }
            
            GameObject item = GameManager.Resouce.Instantiate($"item/Equip/{itemName}/{nickName}");

            item.name = (nickName);
            GameManager.Obj.ItemAdd(item);
            GameManager.Map._mapControll = MapControll.SumItem;
            MapManager.SumPos sumPos = new MapManager.SumPos();
            sumPos = GameManager.Map.CanSum();

            Vector3Int itemPos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            ItemController ic = item.GetOrAddComponent<ItemController>();
            ic.CellPos = itemPos;
            //return item;
        }
    }

    public void PotionCreateEx(PotionStat _itemStat, Dictionary<string, ItemTable> TableDict, Dictionary<int, PotionStat> StatDict, string itemName)
    {
        ItemTable _itemTableDict = null;
        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                _itemTableDict = TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                _itemTableDict = TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                _itemTableDict = TableDict["FirckArti"];
                break;
        }

        int startNum = _itemTableDict._startNum; //딕 시작값
        int endNum = _itemTableDict._endNum; //딕 끝값
        //int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        for (int i = startNum; i < endNum + 1; i++)
        {
            string nickName; //리턴용
            PotionStat itemNum = StatDict[i];// 나중에 random으로 수정
            nickName = itemNum._NickName;

            GameObject item = GameManager.Resouce.Instantiate($"item/Consumable/{itemName}/{nickName}");

            item.name = (nickName);
            GameManager.Obj.ItemAdd(item);
            GameManager.Map._mapControll = MapControll.SumItem;
            MapManager.SumPos sumPos = new MapManager.SumPos();
            sumPos = GameManager.Map.CanSum();

            Vector3Int itemPos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            ItemController ic = item.GetOrAddComponent<ItemController>();
            ic.CellPos = itemPos;
        }
    }

    public void ScrollCreateEx(PotionStat _itemStat, Dictionary<string, ItemTable> TableDict, Dictionary<int, PotionStat> StatDict, string itemName)
    {
        ItemTable _itemTableDict = null;
        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                _itemTableDict = TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                _itemTableDict = TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                _itemTableDict = TableDict["FirckArti"];
                break;
        }

        int startNum = _itemTableDict._startNum; //딕 시작값
        int endNum = _itemTableDict._endNum; //딕 끝값
        //int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        for (int i = startNum; i < endNum + 1; i++)
        {
            string nickName; //리턴용
            PotionStat itemNum = StatDict[i];// 나중에 random으로 수정
            nickName = itemNum._NickName;

            GameObject item = GameManager.Resouce.Instantiate($"item/Consumable/{itemName}/{nickName}");

            item.name = (nickName);
            GameManager.Obj.ItemAdd(item);
            GameManager.Map._mapControll = MapControll.SumItem;
            MapManager.SumPos sumPos = new MapManager.SumPos();
            sumPos = GameManager.Map.CanSum();

            Vector3Int itemPos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            ItemController ic = item.GetOrAddComponent<ItemController>();
            ic.CellPos = itemPos;
        }
    }



    #endregion
}
