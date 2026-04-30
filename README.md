# CommonUI

併用的なUIを使用した、チュートリアルのライブラリです。

ここに画像を記載する

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
本ライブラリを任意のプロジェクトに追加した後、'Tutorial'PrefabをCanvas上に配置してください。
任意のスクリプトに'TextBoxPresenter'の変数を追加し、'StartTutorial()'を実行することでチュートリアルを開始します。
コード貼りたいね。

チュートリアルの要素として'TextBoxMasterData'があります。以下の項目で設定が可能です。

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
