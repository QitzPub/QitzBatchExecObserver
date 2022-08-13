# QitzBatchExecObserver

Windowsのバッチ実行監視システムです。

# 概要

こちらは、Windows中やMacで該当のフォルダを監視して、指定ファイルが生成されたタイミングで指定された.shを実行するというシステムとなっています。
<br>
<img width="933" alt="スクリーンショット 2022-08-13 16 27 11" src="https://user-images.githubusercontent.com/44431516/184473822-1317fec9-3203-4587-acfc-bef890e5235b.png">
<br>
例) C:\Users\Administrator\Desktop\SwitchBuildWindowsSystem のフォルダ中に.request　ファイルが生成されたタイミングで　hoge.shを実行したい。

## なぜこんな周りくどいことをしてシェルを実行するのか・・・？？？！

Windowsサーバー以外の外部からシェルを実行したかったのですが、DockerでIPのポートをあけてそこからシェルを実行するとWindowsのディフェンダーに不正なアクセス扱いされて、処理をとめられた為です・・・・
（WindowsDeffenderを停止させる方法もあるようですが、セキュリティ上あぶないので、停止させない方向で実装すすめました）

#　インストール
https://github.com/QitzPub/QitzBatchExecObserver/tree/master/Builds
<br>
以下のファイル群をWindows中にダウンロードし、QitzBatchExecObserver.exeを実行します。
<br>

# 使い方

<img width="952" alt="スクリーンショット 2022-08-13 16 35 11" src="https://user-images.githubusercontent.com/44431516/184474148-4b15f959-389e-4c0d-b5d5-22c3564cc49c.png"><br>
<br>
「要素を生成」ボタン押下で新しい実行要素を作成します。<br>
「監視フォルダーを選択」ボタン押下で.requestの監視対象ファイルを選択します。<br>
「実行Batchを選択」ボタン押下で.requestが生成されたときに実行する.shのバッチを選択します。<br>


