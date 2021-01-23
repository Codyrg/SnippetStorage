# SnippetStorage
A simple command line utility for storing code snippets

**Store a snippet**

`snippetstorage store -n <name to store> -p <path to snippet file>`

Providing a name that already exists will overwrite the stored snippet.
___
**List your stored snippet(s)**

The following will list the names of all presntly stored snippets:

`snippetstorage list`

Optionally, you can provide the name of a stored snippet in order to view its content

`snippetstorage list -n <name of snippet to view>`
___
**Copy a snippet's contents to your clipboard**

`snippetstorage copy -n <name of snippet to copy to your clipboard>`
__
**Generate a file with your snippet**

`snippetstorage generate -n <name of snippet to generate>`

Optionally, you can provide the name of the path of the file to generate. Otherwise, the snippet will be generated in the current working directory with the name it is stored with.

`snippetstorage generate -n <name of snippet to generate> -p <path to generate snippet at>`
___
**Delete a stored snippet**

`snippetstorage delete -n <name of snippet to delete>`

___
### Future features:
- Templates that can be filled in
- Importing, exporting and merging snippet collections
- Some sort of remote storage for snippets that can be easily shared across multiple machines
- Add tagging to stored snippets