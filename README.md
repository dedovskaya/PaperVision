# PaperVision: Immersive Visualization of Porous Materials and Their PNMs
PaperVision is a virtual reality application built on Unity, designed to offer an immersive and interactive platform for visualizing and analyzing porous material samples along with their associated pore networks. 
The application leverages 3D images obtained from micro-CT scans of materials, processing them to extract the porous network and generate a comprehensive 3D model. Within the main room, users can interact with the sample, exploring it from various angles, rotating, transforming, adjusting colors, and inspecting individual nodes and edges. Additionally, the application offers the capability to run simulations. It is tailored for educational purposes and caters to researchers utilizing pore network modeling techniques, or those visualizing the outcomes of micro-CT scanning without prior experience with pore network modeling.

NOTE: The complete code will be made publicly available upon the publication of the thesis in March 2024.

<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/fd32c12e-fa3c-4a12-975a-330b06b23265" width="900">
</p>

<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/61552b8f-fc44-47e8-8652-86d028b0778a" width="700">
</p>

## Pore Network Modelling
<a href="https://openpnm.org/">Pore Network Modeling</a> is a computational approach in materials science, representing porous structures as interconnected networks. It simulates fluid flow and transport in porous media, offering insights into macroscopic properties. <a href="https://openpnm.org/">OpenPNM</a> is a Python package facilitating Pore Network Modeling. It provides tools for creating realistic pore networks, simulating fluid flow, incorporating experimental data, and visualizing results, enhancing research in porous media applications.

## Conceptual Architecture

### Main Visualization Room
The main room of the PaperVision provides access to the paper model and its corresponding network. Users can interact with the model and network using a *Hand menu* interface.

#### Main Features:
- **3D Model and Network:** A 3D model of paper and its corresponding network, with pores represented as spherical entities and throats as lines in 3D space.
- **Hand Menu Interface:** Interactive interface offering controls such as *Transforms*, *Color*, *Animation*, *Mercury Intrusion Simulation*, *Stokes Flow Simulation*, *Cross-Section*, *Filter* and more.
- **Statistical Panels:** Panels displaying insightful information and distributions of network properties.
- **Tooltip Feature:** Instant access to valuable information regarding individual nodes, enhancing user engagement and understanding.

<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/cccd1dac-ce56-4d4b-ae38-94a07415b8b8" width="700">
</p>

<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/b7c7ce14-7695-4103-9664-574b1ed535f3" width="700">
</p>

### Sample Walkthrough Room
The *Sample Walkthrough* room is dedicated to enabling users to explore a three-dimensional paper model. Users can navigate by walking or teleporting within the model, ensuring a thorough and engaging exploration experience. The *Hand menu* features a teleportation button for maintaining orientation.

<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/0f0e5c01-a438-4e2d-b45d-79b775e33e70" width="700">
</p>

### Screenshot Room
The *Screenshot* room serves as a platform for capturing images of paper samples. Users can precisely position the cross-section plane using the cross-section tool in the *Hand menu* and capture screenshots with a VR controller button. The room is designed with background walls behaving as a greenscreen for optimal image quality.

#### Capture Screenshot Example:
<p align="center">
<img src="https://github.com/dedovskaya/PaperVision/assets/71874540/752030ba-d3cb-4043-b7fc-7159e37100a9" width="400">
</p>

## Author
Ekaterina Baikova, 2023

