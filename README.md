# Graphical-Password-Using-Image-Segmentation
The project allows user to input an image as its password and only user knows what the image looks like as a whole. On receiving the image the system segments the image into an array of images and stores them accordingly. The next time user logs on to the system the segmented image is received by the system in a jumbled order. Now if user chooses the parts of image in an order so as to make the original image he sent then user is considered authentic. Else the user is not granted access. The system uses image segmentation based on coordinates. The coordinates of the segmented image allow the system to fragment the image and store it in different parts. Actually system segments the image into a grid and stores each part accordingly in order. But while logging in the image is shown as broken and in a jumbled order. At this time only the user who provided the image knows what the actual image looks like and he must the parts in horizontal direction from left to right one row at a time according to the order in which parts were arranged in the original image. So the user is granted access after successful attempt.


Modules:

    Image Submission: User can submit image.
    Image Fragmentation: System then fragments/ divides the image into a 8*8 grid.
    Image parts storage: The image parts are separated and stored accordingly.
    Part Jumbling: The parts are then provides to user in a jumbled order.
    Authentication: After selecting the parts in order of original image a successful authentication is done else not.
