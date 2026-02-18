# 家計簿アプリ 開発仕様書 (Draft)

ASP.NET Core と Azure を活用した、AIレシート解析機能付き家計簿アプリの設計仕様です。

## 1. プロジェクト概要
* **アプリ名:** スマート家計簿（仮）
* **ターゲット:** 手入力の手間を減らし、支出の傾向を可視化したいユーザー
* **コア価値:** レシート撮影による自動入力と、Azureを活用したスピーディな分析

---

## 2. システムアーキテクチャ
AzureのPaaS環境をフル活用し、スケーラビリティと低コストな運用を両立します。

| レイヤー | コンポーネント | 役割 |
| :--- | :--- | :--- |
| **Frontend/Backend** | ASP.NET Core (MVC/Razor Pages) | ユーザーUI、ビジネスロジック、APIエンドポイント |
| **Database** | Azure SQL Database | ユーザー、取引、カテゴリデータの管理 |
| **AI / OCR** | Azure AI Document Intelligence | レシート画像からのテキスト・金額抽出 |
| **Storage** | Azure Blob Storage | レシート画像ファイルの保存 |
| **Authentication** | ASP.NET Core Identity | ユーザー認証・認可 |



---

## 3. 機能要件

### 3.1 ホーム画面（ダッシュボード）
* **収支サマリー:** 当月の「総収入」「総支出」「差引残高」を表示。
* **カテゴリ別支出:** 当月の支出内訳を円グラフ（Chart.js等）で表示。

### 3.2 登録機能
* **手動登録:** カテゴリ（プルダウン選択）、金額、収支区分、日付、メモを入力。
* **AIレシート登録:** 1.  画像アップロード → Blob Storage保存。
    2.  AI解析により「日付」「金額」「店舗名（メモ）」「推定カテゴリ」を自動抽出。
    3.  ユーザーが確認・修正した後にDB保存。

### 3.3 データ分析画面
* **月次推移グラフ:** 過去数ヶ月の収入・支出を折れ線グラフで比較表示。
* **カテゴリ別推移:** 特定カテゴリ（例：外食費）の月ごとの増減を確認。
* **履歴一覧:** データのフィルタリング（期間・カテゴリ別）と編集・削除。

---

## 4. データベース設計（主要エンティティ）

### Transactions (取引)
| Column | Type | Description |
| :--- | :--- | :--- |
| `Id` | int (PK) | ユニークID |
| `UserId` | nvarchar | ユーザー識別子 |
| `Amount` | decimal(18,2) | 金額 |
| `IsIncome` | bit | 0:支出, 1:収入 |
| `CategoryId` | int (FK) | Categoriesテーブルへの外部キー |
| `Date` | datetime | 決済日 |
| `Memo` | nvarchar(500) | 備考・店舗名 |
| `ImageUrl` | nvarchar | Blob Storageの画像URL |

### Categories (カテゴリ)
| Column | Type | Description |
| :--- | :--- | :--- |
| `Id` | int (PK) | ユニークID |
| `Name` | nvarchar(50) | カテゴリ名（食費、日用品、光熱費など） |

---

## 5. UI/UX 設計指針
* **レスポンシブデザイン:** BootstrapまたはTailwind CSSを使用し、スマホからの入力を最適化。
* **即時フィードバック:** AI解析中はローディングアニメーションを表示し、ユーザーを待たせない工夫。

---

## 6. フェーズ別ロードマップ
1.  **Phase 1:** 基本的なCRUD（登録・編集・削除）とダッシュボードの実装。
2.  **Phase 2:** Azure AI Document Intelligence との連携（レシート解析）。
3.  **Phase 3:** グラフ表示の高度化、複数アカウント（口座別）管理。