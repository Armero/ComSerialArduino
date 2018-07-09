function PlotArduinoData (path, filename)

initialDir = pwd;
tempFile = 'temp.csv';
cd (path);
Data = fileread(filename);
Data = strrep(Data, ',', '.');
Data = strrep(Data, ';', ',');
FID = fopen(tempFile, 'w');
fwrite(FID, Data, 'char');
fclose(FID);

data = csvread(tempFile);

figure(1)
dataArray = zeros(size(data,1), 4 ,2);
for i = 1:4
    idx = data(:,2) == (i-1);
    
    if (~isempty(idx))
        dataArray(idx,i,1) = data(idx, 1);
        dataArray(idx,i,2) = data(idx, 3);
    end
end

subplot(2,2,1)
idx = dataArray(:, 1, 1) ~= 0;
x = dataArray(idx, 1, 1);
y = dataArray(idx, 1, 2);
plot(x, y)
title('Tachometer')

subplot(2,2,2)
idx = dataArray(:, 2, 1) ~= 0;
x = dataArray(idx, 2, 1);
y = dataArray(idx, 2, 2);
plot(x, y)
title('LM35')

subplot(2,2,3)
idx = dataArray(:, 3, 1) ~= 0;
x = dataArray(idx, 3, 1);
y = dataArray(idx, 3, 2);
plot(x, y)
title('TPS')

subplot(2,2,4)
idx = dataArray(:, 4, 1) ~= 0;
x = dataArray(idx, 4, 1);
y = dataArray(idx, 4, 2);
plot(x, y)
title('DS18B20')

delete (tempFile)
cd (initialDir);