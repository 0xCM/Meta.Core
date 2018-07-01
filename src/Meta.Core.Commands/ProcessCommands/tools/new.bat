mkdir %1
cd %1
echo new %1 %2> %1.new.bat
%1 %2 >%1.info
cd ..
