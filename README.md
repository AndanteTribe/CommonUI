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
   - ゲームの世界観を破綻しない汎用的なデザイン

## 使い方
本ライブラリを任意のプロジェクトに追加した後、`Prefabs/Tutorial`をCanvas上に配置してください。

<img width="293" height="242" alt="image" src="https://github.com/user-attachments/assets/c31d4cff-1348-476a-b5b3-4a21f3e5be11" />

`Prefabs/Tutorial`内に`TextData`があります。
これがチュートリアルで表示されるテキストのマスターデータです。
この`TextData`は本ライブラリ導入後、Projectから`Create Model/TextBoxMasterData`から作成可能です。

<img width="569" height="154" alt="image" src="https://github.com/user-attachments/assets/4cb1b36f-ca23-4e81-b907-9fb79218210b" />

テキストのマスターデータは以下の通りに設定可能です。

<img width="533" height="445" alt="image" src="https://github.com/user-attachments/assets/d95d7dc7-47f8-45b6-bfe3-9bed30289ea6" />

| 名前 | 説明 |
| ---: | :--- |
| Charactor | キャラクターアイコンに設定する画像です。使用したいスプライトを指定すると、自動的にキャラクター用のテキストボックスに変化しスプライトが適用されます。 |
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

設定後、任意のスクリプトに'TextBasePresenter'の変数を追加し、'StartTutorial()'を実行することでチュートリアルを開始します。

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
- [IBM Plex Sans JP](https://fonts.google.com/specimen/IBM+Plex+Sans+JP)
   - テキストボックス内の文字のフォントに使用しています。
- [SoftMaskForUGUI](https://github.com/mob-sakai/SoftMaskForUGUI)
   - フォーカス部分のくり抜きに使用しています。
- [LitMotion](https://github.com/annulusgames/LitMotion/tree/main)
   - コーチマークやページ機能の表記アニメーションに使用しています。
- [Utils](https://github.com/AndanteTribe/Utils)
   - エフェクトに使用しています。
