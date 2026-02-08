# 📄 MILESTONE 3 — REQUIREMENTS DOCUMENT

## Filtered Echo Bot

### 1. Overview

**Milestone Name:** Filtered Echo Bot
**Goal:** Bot zararli yoki nomaqbul xabarlarni aniqlay olishi

---

### 2. Problem Statement

Bot hozirgacha barcha xabarlarni qaytaradi va moderatsiya yo‘q. Bu spam, so‘kinish va zararli linklarga yo‘l ochadi.

---

### 3. Scope

### ✅ In Scope

- So‘kinishlarni aniqlash
- URL aniqlash
- CAPS (baland harf) matnni aniqlash
- Bloklangan xabarga ogohlantirish qaytarish

### ❌ Out of Scope

- AI moderation
- Database saqlash
- Admin panel

---

### 4. Functional Requirements

| ID  | Requirement                                           |
| --- | ----------------------------------------------------- |
| FR1 | Bot link mavjudligini aniqlay olishi kerak            |
| FR2 | Bot bloklangan so‘zlar ro‘yxatini tekshirishi kerak   |
| FR3 | Bot CAPS (hammasi katta harf) xabarni aniqlashi kerak |
| FR4 | Bloklangan xabar o‘rniga warning yuborilishi kerak    |
| FR5 | Ruxsat etilgan xabarlar normal qaytarilishi kerak     |

---

### 5. Non-Functional Requirements

| ID   | Requirement                                   |
| ---- | --------------------------------------------- |
| NFR1 | Filtrlash real vaqtga yaqin bo‘lishi kerak    |
| NFR2 | Yangi filter qo‘shish oson bo‘lishi kerak     |
| NFR3 | Bot filtrlash sababli crash bo‘lmasligi kerak |

---

### 6. Success Criteria

- Link yuborilganda ogohlantirish chiqadi
- So‘kinish bloklanadi
- Oddiy xabarlar ishlaydi
