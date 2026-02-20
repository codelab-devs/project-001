# 📄 MILESTONE 2 — REQUIREMENTS DOCUMENT

## Smart Echo Bot

### 1. Overview

**Milestone Name:** Smart Echo Bot

**Goal:** Bot turli xil message turlarini tushunishi va mos javob berishi

---

### 2. Problem Statement

Oddiy echo bot faqat textni qaytaradi, lekin real Telegram botlar message turiga qarab har xil javob qaytarishi kerak.

---

### 3. Scope

### ✅ In Scope

- `/start` command ishlashi
- Text, Photo, Sticker aniqlanishi
- User ma’lumotlari olinishi

### ❌ Out of Scope

- Database saqlash
- Inline keyboard
- Admin panel
- File download

---

### 4. Functional Requirements

| ID  | Requirement                                                           |
| --- | --------------------------------------------------------------------- |
| FR1 | Bot `/start` komandani tanishi kerak                                  |
| FR2 | `/start` yuborilganda welcome message chiqishi kerak                  |
| FR3 | Photo kelganda maxsus javob berishi kerak                             |
| FR4 | Sticker kelganda sticker ID qaytarishi kerak                          |
| FR5 | Bot message yuborgan userning ismi va username’ini o‘qiy olishi kerak |
| FR6 | Bot message turini aniqlay olishi kerak                               |

---

### 5. Non-Functional Requirements

| ID   | Requirement                                          |
| ---- | ---------------------------------------------------- |
| NFR1 | Noto‘g‘ri formatdagi update botni yiqitmasligi kerak |
| NFR2 | Null qiymatlar xavfsiz ishlanishi kerak              |
| NFR3 | Kod kengaytiriladigan bo‘lishi kerak                 |

---

### 6. Success Criteria

- `/start` ishlaydi
- Photo va Sticker farqlanadi
- Bot crash bo‘lmaydi
