# .me - Digital Life Organizer

**.me** is a secure, offline-first digital vault designed to help students and professionals declutter their physical documents. Think of it as a password manager, but specifically built for your most important physical IDs, government forms, certifications, and academic papers. 

Because privacy is our highest priority, **.me is 100% offline**. Your data never leaves your device.

## ✨ Core Features

* **🔒 Secure Document Vault:** Categorize and store SSS, BIR, PhilHealth, Passports, Diplomas, and more.
* **🚫 100% Offline & Encrypted:** All data and images are stored locally using AES-256 encryption. No cloud, no tracking, no data breaches.
* **🪪 The ".me Card":** Generate a customizable, dynamic Virtual ID or Business Card with a scannable QR code.
* **⏰ Expiry Tracker:** Receive local device notifications when your licenses or documents are nearing expiration.
* **📱 Biometric Lock:** Secure your vault behind your device's native Fingerprint or FaceID.

## 🛠️ Tech Stack

This application is built using a modern, cross-platform architecture:
* **Framework:** .NET 8 MAUI (Multi-platform App UI)
* **UI Architecture:** Blazor Hybrid (HTML/CSS/C#)
* **Styling:** Tailwind CSS
* **Database:** Encrypted SQLite (SQLCipher)

## 🚀 Getting Started

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) (with the **.NET Multi-platform App UI development** workload installed) OR Visual Studio Code with the C# Dev Kit and MAUI extensions.
* Node.js (for processing Tailwind CSS)

### Installation & Running Locally

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yourusername/me.app.git](https://github.com/yourusername/me.app.git)
    cd me.app/Me.App
    ```

2.  **Install Frontend Dependencies (Tailwind CSS):**
    ```bash
    npm install
    npm run build:css
    ```

3.  **Run the Application:**
    * **Using Visual Studio:** Open `Me.App.slnx`, select your target emulator (Android/Windows/MacCatalyst), and hit `F5`.
    * **Using CLI:**
        ```bash
        dotnet build
        dotnet run -f net8.0-android # Or net8.0-windows10.0.19041.0, etc.
        ```

## 🛡️ Privacy Policy Statement
**.me** requires **zero internet permissions**. The application does not collect, transmit, or sell any telemetry or user data. Your files are encrypted and reside solely on your device's internal storage.

## 🤝 Contributing
Currently, this project is in active core development. Please refer to the Project Roadmap before submitting pull requests.