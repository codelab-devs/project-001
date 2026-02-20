# 📄 MILESTONE 4 — REQUIREMENTS DOCUMENT

## Contextual (Stateful) Echo Bot

### 1. Overview

**Milestone Name:** Contextual Echo Bot

**Goal:** Bot foydalanuvchi suhbat tarixini eslab qolishi

---

### 2. Problem Statement

Bot avvalgi xabarlarni eslamaydi, shu sabab suhbat konteksti yo‘qoladi va bot faqat stateless javob qaytaradi.

---

### 3. Scope

### ✅ In Scope

- Har user uchun oxirgi message saqlash
- Message history bazaga yozilishi
- `/history` komandasi orqali oxirgi xabar ko‘rsatilishi
- User session tushunchasi

### ❌ Out of Scope

- Full chat export
- AI conversation
- Admin panel

---

### 4. Functional Requirements

| ID  | Requirement                                          |
| --- | ---------------------------------------------------- |
| FR1 | Har yuborilgan message DB ga yozilishi kerak         |
| FR2 | Message user bilan bog‘lanishi kerak                 |
| FR3 | `/history` komandasi oxirgi xabarni qaytarishi kerak |
| FR4 | Bot history mavjud bo‘lmasa xato bermasligi kerak    |
| FR5 | Bot normal javob jarayonini saqlab qolishi kerak     |

---

### 5. Non-Functional Requirements

| ID   | Requirement                                      |
| ---- | ------------------------------------------------ |
| NFR1 | Ma’lumotlar persist bo‘lishi kerak               |
| NFR2 | 10k user history ko‘tara olishi kerak            |
| NFR3 | DB bilan ishlash botni sekinlashtirmasligi kerak |

---

### 6. Success Criteria

- Xabarlar bazada saqlanadi
- `/history` ishlaydi
- Bot stateful bo‘ladi
