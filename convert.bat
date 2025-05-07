@echo off
"C:\Program Files\Pandoc\pandoc.exe" "main (1).tex" -o output.docx --standalone --toc --number-sections --highlight-style=tango --pdf-engine=xelatex
pause 