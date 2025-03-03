# 🧮 TruthTableGenerator

**TruthTableGenerator** est un outil en ligne de commande qui génère une **table de vérité** pour des expressions logiques données.

## 📥 Installation

Téléchargez la version correspondant à votre système d'exploitation :

- **Windows** : [TruthTableGenerator.exe](https://github.com/Fenitr/Boolean/blob/master/path/winx64/TruthTableGenerator.exe)
- **Linux** : [TruthTableGenerator](https://github.com/Fenitr/Boolean/blob/master/path/linux64/TruthTableGenerator)
- **macOS** : [TruthTableGenerator](https://github.com/Fenitr/Boolean/blob/master/path/macOs64/TruthTableGenerator)

---

## 💻 Installation sur **Windows**

1. Téléchargez le fichier `TruthTableGenerator.exe` pour **Windows**.
2. Créer un nfichier `TruthTableGenerator.bat` dans le même dossier et ajouter
    ```sh
       @echo off
        "C:\Tools\TruthTableGenerator\TruthTableGenerator.exe" %*
    ```
4. Placez le fichier dans un dossier comme `C:\Tools\` (ou un autre répertoire de votre choix).
5. Ajouter ces derniers dans la variable de développement de votre PC
6. Ouvrez l'invite de commandes (`cmd`) et exécutez la commande suivante pour tester :

    ```sh
    truth-table "(a -> ~b) == (b | a)"
    ```

---

## 🐧 Installation sur **Linux**

1. Téléchargez le fichier **TruthTableGenerator** pour **Linux**.
2. Placez le fichier téléchargé dans un répertoire, par exemple, `/usr/local/bin/`.
3. Ouvrez un terminal et donnez les permissions d'exécution avec la commande :

    ```sh
    sudo chmod +x /path/to/TruthTableGenerator
    ```

    Assurez-vous que le chemin pointe vers le fichier téléchargé.

4. Utilisation :


     ```sh
     TruthTableGenerator  "(a -> ~b) == (b | a)"
     ```


## 🍏 Installation sur **macOS**

1. Téléchargez le fichier **TruthTableGenerator** pour **macOS**.
2. Placez le fichier téléchargé dans un répertoire, comme `/usr/local/bin/`.
3. Ouvrez un terminal et donnez les permissions d'exécution avec la commande :

    ```sh
    sudo chmod +x /path/to/TruthTableGenerator
    ```

4. Utilisation:

    ```sh
   TruthTableGenerator  "(a -> ~b) == (b | a)"
    ```
