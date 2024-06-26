# 🏠 인형의 집 🪆

![image](https://github.com/A2-dollhouse/dollhousePublic/assets/167046397/f2356b74-ecc0-4647-968a-9e8e5a032590)

<br/>

> *2024.06.19.  ~  2024.06.26. 개발 완료*

<br/>

플레이어가 인형의 집에 떨어졌습니다. 3개의 열쇠를 찾아 열린 문으로 무사히 탈출하는 공포 게임입니다.

<br/><br/>

[👉팀 노션으로 이동](https://www.notion.so/teamsparta/d93c963485174f189cc2b2345d402b4b)
<br/><br/>

[➡️게임 플레이하기](https://drive.google.com/file/d/1eSon-xWuU9-S-hPNVoUB1PYxl4eyykr5/view)

<br/><br/>

#  목차 
```
1. 팀원 소개
2. 개발 환경
3. 주요 기능
4. 버전 업데이트
5. 기능 세부
```

<br/><br/>

#  팀원 소개
* 정이현 --- 팀장, UI 디자인 및 게임 정보창 정리
* 곽경훈 --- 열쇠 및 클리어 로직 담당 ~~(깃허브 연쇄폭탄마)~~
* 문주원 --- 플레이어 손전등 및 플래시라이트 세팅
* 신재원 --- 플레이어 뒤를 따라오는 AI Enemy 작업
* 정해성 --- 맵 전체 구조 기획 및 오브젝트 담당

<br/><br/>
 
# ⚙ 개발 환경

* ``C#``
* ``Unity 2022.3.17f (LTS)``
* ``Visual Studio 2022``
* ``.Net 8.0``
* ``Dungeon - Low Poly Toon Battle Arena Version 1.1（current)``

<br/><br/>
 
# 🎮 주요 기능
1. 플레이어 이동
2. 장애물
3. 열쇠 오브젝트
4. 캐릭터 애니메이션
5. 게임 정보창
   
<br/><br/>

# 💫 버전 업데이트 
```
인형의 집 ver.01
```
* Last Update - Jun 25, 2024

<br/>

# 🌲 기능 세부 🌲

### 이동 및 상호작용
``WASD`` 키로 이동합니다.

``F`` 키로 손전등을 켜고 끌 수 있습니다.

``E`` 키는 상호작용으로, 게임 정보창과 문을 열고 닫을 때 사용합니다.

<br/>

### 장애물
플레이어의 뒤에서 따라오는 ``인형`` 과 부딪히면 게임이 끝납니다.

<br/>

### 열쇠 오브젝트
맵에 놓여 있는 ``3개의 열쇠`` 를 먹으면 화면 왼쪽 상단에 먹은 갯수만큼 표시가 됩니다.

열쇠를 다 먹으면 맵 어딘가에 ``탈출구`` 가 나타납니다.

<br/>

### 게임 정보창
게임 시작 후 1초 뒤에 게임의 설명이 나타나는 창이 보입니다. 게임 설명, 이동 방법, 주의사항 순으로 표시됩니다.

창을 넘길 때는 ``E`` 키를 사용해서 넘기고 닫을 수 있습니다.

<br/> <br/>
