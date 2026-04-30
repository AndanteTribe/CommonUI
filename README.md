# CommonUI

併用的なUIを使用した、チュートリアルのライブラリです。
<img width="1920" height="1080" alt="Image Sequence_003_0195" src="https://github.com/user-attachments/assets/84fb26d8-d95c-4f77-9d2f-b2bd69367311" />

## 概要
コーチマーク型のオンボーディングUIとして、各種ゲームで横断的に使用できる汎用システム及びUI画面を備えたライブラリです。

本ライブラリでは以下の要項が備わっています。
- 追加の実装・デザインが可能な拡張性
   - ゲーム固有のデザイン及び実装に対して柔軟に対応できるシステム
- 安価な導入コスト
   - ゲームジャムのような開発期間が短いケースで負荷にならない
- 汎用性の高いデザイン
   - 追加の拡張を認めつつ、標準のままでも製品の品質を落とさないデザイン
   - ゲームの世界観を破綻させない汎用的なデザイン

## 使い方
本ライブラリを任意のプロジェクトに追加した後、`Prefabs/Tutorial`をCanvas上に配置してください。

<img width="293" height="242" alt="image" src="https://github.com/user-attachments/assets/c31d4cff-1348-476a-b5b3-4a21f3e5be11" />

`Prefabs/Tutorial`の`_textData`には`TextBoxMasterData`が割り当てられます。
これがチュートリアルで表示されるテキストのマスターデータです。
`TextBoxMasterData`は本ライブラリ導入後、Projectから`Create Model/TextBoxMasterData`で作成可能です。

<img width="569" height="154" alt="image" src="https://github.com/user-attachments/assets/4cb1b36f-ca23-4e81-b907-9fb79218210b" />

テキストのマスターデータは以下の通りに設定可能です。

<img width="533" height="445" alt="image" src="https://github.com/user-attachments/assets/d95d7dc7-47f8-45b6-bfe3-9bed30289ea6" />

| 名前 | 説明 |
| ---: | :--- |
| Character | キャラクターアイコンに設定する画像です。使用したいスプライトを指定すると、自動的にキャラクター用のテキストボックスに変化しスプライトが適用されます。 |
| Position | テキストボックスを画面のどこに位置するか選択できます。8端 + 中央に位置できます。 |
| Radius Vertical Offset | テキストボックスをフォーカスしたオブジェクトからどれほど離した位置に置くか、オフセットを設定できます(垂直方向) |
| Radius Horizontal Offset | テキストボックスをフォーカスしたオブジェクトからどれほど離した位置に置くか、オフセットを設定できます(水平方向) |
|  |  |
| Models | テキストボックスに表示されるテキストの項目です。テキストを複数設定すると、ページとして機能を果たします。 |
| Models - Text | テキストボックスに表示されるテキストです。設定した値がテキストボックスに表示されます。3行以内に収めて使用してください。 |
| Models - CoachMark | そのテキストが表示されている間、フォーカスされるコーチマークの設定です。 |
| Models - CoachMark - Shape | コーチマークの形です。長方形・円形の2種類が選択できます。 |
| Models - CoachMark - Is Gradiate | コーチマークのグラデーションを有効にするか設定できます。 |
| Models - CoachMark - Radius | 長方形: UIに完全に当てはまる、最小の大きさからさらに大きさを増やすか、半径の値で設定できます。<br>円形: コーチマークの半径の設定ができます。 |
| Models - CoachMark - Padding Radius | グラデーション有効時のみ使用可能 <br>グラデーションの余白部分の割合を増やします(0 ~ 1) |
| Models - CoachMark - Gradiate Radius | グラデーション有効時のみ使用可能 <br>グラデーション部分の割合を増やします(0 ~ 1) |
| Models - CoachMark - Target Object Name | オブジェクトの名前を指定します。指定するとコーチマークがそのオブジェクトにフォーカスをします。 |
| Models - Is Finger Icon Enabled | 指アイコンを表示するか選択できます。 |
| Models - Finger Icon Direction | 指アイコンの向きを設定できます。 |
| Models - Is Effect Enabled | エフェクトを表示するか選択できます。 |

設定後、任意のスクリプトに`TextBasePresenter`の変数を追加し、`StartTutorial()`を実行することでチュートリアルを開始します。

```c#
using UnityEngine;
using CommonUI.Tutorial;

/// <summary>
/// チュートリアルを起動させるためのクラス
/// </summary>
public class TutorialStarter: MonoBehaviour
{
    [SerializeField, Tooltip("チュートリアルの管理クラス")]
    private TextBasePresenter _tutorialPresenter;

    private void Start()
    {
        _tutorialPresenter.StartTutorial();
    }
}
```

## 生産者表記

ディレクター
- [胡蝶の夢](https://github.com/kochounoyume)
- [やげっち](https://github.com/tachu105)

プランナー
- [Core](https://fori.io/atsutoshi-kodama0629)
- [ロペ](https://x.com/Ropera_88)

エンジニア
- [ロペ](https://x.com/Ropera_88)
- [ぬー](https://github.com/asahinnnure)

UIデザイナー
- [ANEHATA](https://github.com/ANEHATA)
- [Rinbou](https://github.com/Rinbou-0001)
- [やぎ](https://github.com/Goatee888)

## ライセンス
このライブラリはMITライセンスの下、公開されています。

## 謝辞
ライブラリ制作にあたり、使用したフォント・ライブラリを記載します。
***
### [IBM Plex Sans JP](https://fonts.google.com/specimen/IBM+Plex+Sans+JP)
Copyright © 2017 IBM Corp. with Reserved Font Name "Plex"

This Font Software is licensed under the SIL Open Font License, Version 1.1.

This license is copied below, and is also available with a FAQ at:

https://openfontlicense.org
***
### [SoftMaskForUGUI](https://github.com/mob-sakai/SoftMaskForUGUI)
Copyright 2018-2024 mob-sakai

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
***
### [LitMotion](https://github.com/annulusgames/LitMotion/tree/main)
MIT License

Copyright (c) 2023 Yusuke Nakada

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
***
### [Utils](https://github.com/AndanteTribe/Utils)

MIT License

Copyright (c) 2025 AndanteTribe

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
