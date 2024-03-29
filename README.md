# Unity_Game01

## ゲーム本編は下記URLにてブラウザ（UnityRoom）上で操作可能です。
https://unityroom.com/games/run_slash

## BulletCtrl.cs
- 射撃時の弾丸のスピード及び、弾丸（Prefab）の消滅条件の指定

## CameraCtrl.cs
- プレイヤーに対してX方向のみカメラを追従させる（落下によるゲームオーバー実装の為、上下方向は追従なし）
- 今回はプレイヤーではなく床が動いているがプレイヤーが横に動く際にも使用可

## EffectClear.cs
- エネミーを消滅させた際にエフェクトを消す処理がエラーとなる為、別でエフェクト消滅を処理

## EnemyBullet.cs
- 概ね「BulletCtrl.cs」と同じだがエネミーの弾はプレイヤーの弾によって破壊可能としている

## EnemyManager.cs
- 各エネミー毎にスコアやスピードを設定、攻撃モーションに入る範囲もここで設定
- 攻撃範囲に入ると攻撃がループしてしまう為、コルーチンにより制御
- スコア機能がある為、スコアマネージャーにスコアを渡す
- 指定位置まで移動することでエネミーは消滅

## EnemySponer.cs
- 指定範囲内におけるランダムリスポーン（エネミー）
- スタート時のみ早めにスポーン

## FloatEnemyManager.cs
- 概ね「EnemyManager.cs」と同様だがこちらはプレイヤーのジャンプ（上下）に追従する

## GameoverZone.cs
- 画面左端にゲームオーバー判定を実装し、障害物で詰まった際にゲームオーバーシーンへ遷移

## GroundCheck.cs
- ジャンプを行う為に着地・接地・空中を判定

## MuteCtrl.cs
- スマホ用に設計していた為、BGM/SEがいらない人のためにミュートボタンを実装
- スタートシーンに設定することでボタンを常に表示

## PlayerCtrl.cs
- ジャンプ、射撃、近接、ゲームオーバーなど基本的なことの実装
- 二段ジャンプを実装するにあたってジャンプ回数のカウントと着地時にカウントリセットを実装
- カメラから消えることでゲームオーバー（上下左右）を実装

## RangeEnemyManager.cs
- 概ね「EnemyManager.cs」と同じだがこちらは遠距離攻撃をInstantiateで実装と攻撃間隔を実装（近接エネミーは攻撃を連続で繰り返す）

## Restar.cs
- ハイスコアのセーブを行なっている。（EasySave3にて実装）

## ScoreManager.cs
- ハイスコアと比較しハイスコアの入れ替えを行うかどうかの処理

## SearchEnemy.cs
- 攻撃モーションに入るかどうかの切り替えを行う範囲

## SkyaManager.cs
- スカイボックス（空）を回転させることで奥行きの動きを実装

## SoundCtrl.cs
- BGMの実装

## SpeedCtrl.cs（テスト用）
- スライダーによりスピードを可変させる機能

## StageGenerator.cs
- スタート、リスタート時に10個のステージをランダムに配置する機能（ある程度のランダム性を持たせたかったため）
- ステージのスクロールスピードや、デスポーン、スポーン位置の設定
