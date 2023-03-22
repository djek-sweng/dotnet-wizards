#!/bin/sh

find . \
    -iname "bin" \
    -o -iname "obj" \
    -o -iname "out" \
    -o -iname "dist" \
    -o -iname "TestResults" | xargs rm -rf
