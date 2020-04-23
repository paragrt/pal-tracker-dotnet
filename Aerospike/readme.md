Attempt to measure the cost of storing data in normal format in separate bins vs storing in protobuf encoded bin.

|6 fields	    |Flat	 |Proto	  |Ratio (Flat/Proto)|
|--------------|------|--------|--------|
|1500 Records |319804|263415	|1.2140690545|
|15000Records	|3172197|2607019|1.2167909018|

|21 fields    |Flat   |Proto  |Ratio(Flat/Proto)|
|--------------|------|--------|--------|
|1500 Records |777401	|546603	|1.422240639|
|15000Records |7750983|5442667|1.4241148687|
