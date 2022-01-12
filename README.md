# 2.5D Display Project
### Participants: minyeong97 & herrtane

### 21.08.23-22.01.08

## Abstract
This project aims to develop an illusion of depth of field with an ordinary display. The idea is to adjust the projection matrix according to the relative position of the eye to the display. This is done by calculating the frustrum the display and the eyes make.
We tested the result with Unity Engine combined with Valve Index VR to track the position of the eye. The idea works, but due to glichy input of the eye and incorrect position input of the display makes it hard to enjoy the changing perspective.

## Theoretical Backgrounds
Rendering 3D scene to a 2D display needs 3 matrix multiplications. The first matrix is the translation matrix, which translates and rotates the local position of the object to an absolute axis.
The second matrix is lookAt matrix, which rotates and translates the whole axis to make camera the center.
The third matrix is the projection matrix, which is defined by aov(Angle of View) and display ratio, to generate 2D coordinates with 3D coordinates.
In this project, we focus only on the projection matrix.

To see how the projection matrix works, we can have a look at the frustrum that is present in the scene.


## Project Setup

## The Result


