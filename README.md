# Kindle App

I delete books from my Kindle when I finish them. This leaves an ``.SDR`` folder on my Kindle that I also want to delete.

I can manually get a list of all books and folders in the ``Document`` folder.

An example of a folder is.

```bash
    L:\documents\Aurora - Kim Stanley Robinson.sdr
```

A book.

```bash
    L:\documents\Aurora - Kim Stanley Robinson.azw3
```

So once I delete ``Aurora - Kim Stanley Robinson.azw3`` there is an orphan folder left on my Kindle, ``Aurora - Kim Stanley Robinson.sdr``.

I need to reconcile the list of Kindle books against the list of folders and make a list of all folders that don't have a respective ``.mobi`` or ``.azw3`` book title

Once I have a list of ``.SDR`` folders I will manually delete them from my Kindle.

## Process

Manually create a directory listing of files and folders in the ``Documents`` folder on your Kindle. Name this file **Kindle.txt**.

From this list make a sub list of ``.SDR`` folders. Then make a sub list of all books.

Iterate through the folder list. If you can't find a corresponding ``.mobi`` or ``.azw3`` file then that ``.SDR`` folder is an orphan folder that needs to be removed from my Kindle.

Make a list of orphan folders. Name this list **Folder.txt**.

I could write this list as a batch file to delete the folders with one command or just delete the orphan folders one by one.
