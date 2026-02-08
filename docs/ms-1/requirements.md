# 📄 MILESTONE 1 — REQUIREMENTS DOCUMENT

## Basic Echo Bot

### 1. Overview

**Milestone Name:** Basic Echo Bot
**Goal:** Telegram bot qanday ishlashini amaliy ko‘rsatish

---

### 2. Problem Statement

Boshlovchi dasturchilar Telegram bot arxitekturasini real ishlash jarayonini ko‘rmasdan tushunishda qiynaladi.

---

### 3. Target Users

* Telegram foydalanuvchilari
* Bot bilan ishlashni o‘rganayotgan dasturchilar

---

### 4. Scope

### ✅ In Scope

* Bot text message qabul qiladi
* Xabarni o‘ziga qaytaradi
* Polling orqali ishlaydi

### ❌ Out of Scope

* Database
* Command system
* Inline keyboard
* Media handling

---

### 5. Functional Requirements

| ID  | Requirement                                          |
| --- | ---------------------------------------------------- |
| FR1 | Bot text message qabul qilishi kerak                 |
| FR2 | Qabul qilingan xabar o‘sha userga qaytarilishi kerak |
| FR3 | Bot polling orqali update olishi kerak               |
| FR4 | Bot to‘xtamasdan ishlashi kerak                      |

---

### 6. Non-Functional Requirements

| ID   | Requirement                                          |
| ---- | ---------------------------------------------------- |
| NFR1 | 1 request/sec yuklama ko‘tara olishi                 |
| NFR2 | Console logging bo‘lishi kerak                       |
| NFR3 | Bot crash bo‘lsa qayta ishga tushirish oson bo‘lishi |

---

### 7. Success Criteria

* User yozgan har qanday text aynan qaytadi
* Bot ishlashi barqaror
* Code o‘qilishi oson