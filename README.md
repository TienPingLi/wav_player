# WAV 音效檔播放器

## 一、專案簡介

本專案為「視窗程式設計 (II)」課程中的上課練習：**WAV 音效檔播放器**。

程式使用 C# Windows Forms 製作圖形化介面，並透過 `System.Media.SoundPlayer` 類別播放 `.wav` 音效檔。使用者可以透過檔案選擇視窗瀏覽本機 WAV 檔案，並進行播放一次、重複播放、停止播放與結束程式等操作。

本練習主要目的為熟悉 Windows Forms 介面設計、按鈕事件處理、OpenFileDialog 檔案選擇功能，以及 SoundPlayer 音效播放類別的基本使用方式。

---

## 二、專案功能

本程式提供以下功能：

1. **瀏覽 WAV 檔案**
   - 使用 `OpenFileDialog` 開啟檔案選擇視窗。
   - 僅篩選副檔名為 `.wav` 的音效檔案。
   - 選取後將完整檔案路徑顯示於文字方塊中。

2. **播放一次**
   - 使用 `SoundPlayer.Play()` 播放選取的 WAV 音效檔。
   - 音效播放一次後自動結束。

3. **重複播放**
   - 使用 `SoundPlayer.PlayLooping()` 重複播放音效檔。
   - 會持續播放直到使用者按下「停止播放」。

4. **停止播放**
   - 使用 `SoundPlayer.Stop()` 停止目前正在播放的音效。

5. **結束程式**
   - 按下「結束程式」後會關閉應用程式。
   - 關閉前會顯示確認視窗，避免使用者誤關程式。

6. **錯誤提示**
   - 若尚未選擇檔案就按下播放按鈕，會顯示提醒訊息。
   - 若檔案不存在或播放失敗，會顯示錯誤訊息。

---

## 三、開發環境

| 項目 | 內容 |
|---|---|
| 開發工具 | Visual Studio 2022 |
| 程式語言 | C# |
| 專案類型 | Windows Forms App |
| 使用框架 | .NET Framework / Windows Forms |
| 主要命名空間 | `System.Media`、`System.Windows.Forms`、`System.IO` |

---

## 四、使用技術

本專案主要使用以下技術：

### 1. Windows Forms

Windows Forms 是 C# 用來建立桌面視窗應用程式的技術。本專案使用表單、按鈕、文字方塊、群組框與檔案開啟對話框建立操作介面。

### 2. OpenFileDialog

`OpenFileDialog` 用來讓使用者從電腦中選擇 WAV 音效檔。

```csharp
ofdWAVFile.Filter = "WAV Files (*.wav)|*.wav";
