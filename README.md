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
2. Placez le fichier dans un dossier comme `C:\Tools\` (ou un autre répertoire de votre choix).
3. Ouvrez l'invite de commandes (`cmd`) et exécutez la commande suivante pour tester :

    ```sh
    C:\Tools\TruthTableGenerator\TruthTableGenerator.exe "(a -> ~b) == (b | a)"
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

4. Pour pouvoir utiliser la commande `truth-table` partout dans le terminal, créez un alias ou un script :
   - Créez un fichier exécutable dans `/usr/local/bin/` :

     ```sh
     sudo nano /usr/local/bin/truth-table
     ```

   - Ajoutez le contenu suivant (en remplaçant `/path/to/TruthTableGenerator` par le chemin réel) :

     ```sh
     #!/bin/bash
     /path/to/TruthTableGenerator "$@"
     ```

   - Rendez-le exécutable :

     ```sh
     sudo chmod +x /usr/local/bin/truth-table
     ```

5. Vous pouvez maintenant utiliser la commande `truth-table` dans le terminal :

    ```sh
    truth-table "(a -> ~b) == (b | a)"
    ```

---

## 🍏 Installation sur **macOS**

1. Téléchargez le fichier **TruthTableGenerator** pour **macOS**.
2. Placez le fichier téléchargé dans un répertoire, comme `/usr/local/bin/`.
3. Ouvrez un terminal et donnez les permissions d'exécution avec la commande :

    ```sh
    sudo chmod +x /path/to/TruthTableGenerator
    ```

4. Créez un alias pour l'exécution de la commande en ajoutant cette ligne à votre fichier `~/.bash_profile` ou `~/.zshrc` :

    ```sh
    alias truth-table="/path/to/TruthTableGenerator"
    ```

5. Rechargez votre profil :

    ```sh
    source ~/.bash_profile  # ou source ~/.zshrc
    ```

6. Vous pouvez maintenant utiliser la commande `truth-table` dans le terminal :

    ```sh
    truth-table "(a -> ~b) == (b | a)"
    ```

---

## 🎮 Utilisation

Après l'installation, vous pouvez générer une table de vérité en exécutant la commande suivante dans le terminal ou l'invite de commandes :

```sh
truth-table "(a -> ~b) == (b | a)"
