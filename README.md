# Performance Evaluation Framework

[![Build Status](https://travis-ci.com/JustinMackenzie/Performance-Evaluation-Framework.svg?token=1Ux1AmbxqaJQd9wZmsG2&branch=master)](https://travis-ci.com/JustinMackenzie/Performance-Evaluation-Framework)

A framework developed in C# .NET that provides tools and services for gathering, analyzing and evaluating user performance in augmented reality and virtual reality simulator scenarios.

## Features
 - Create scenarios to run in your simulator. 
 - Collect user performance data in your simulator.
 - Analyze the results of the user's performance. 
 - Evaluate the user's performance.

## Framework Structure
The framework contains many different software applications and components that work together to achieve various goals. The framework components are organized into their specific goal. The components are as followed:

Services:

 - Assistive Learning
 - Evaluation
 - Logging
 - Performance Management
 - Performance Processing
 - Playback
 - Repository
 - Scenario Management
 - Serialization
 - Simulator Runtime
 - Core Performance Domain

Applications:

 - Scenario Creator Console Application
 - Scenario Creator Web Application
 - Performance Analysis Application
 - Performance Evaluation Service
 - User Performance Evaluation REST API Server

## Architecture
The architecture of the framework is separated into several layers:

 - Core
 - Services
 - Infrastructure
 - Applications

### Core
The core layer contains the domain model and the abstractions used to store and retrieve these entities. The domain model contains entities and value objects used to define the various domain concepts and objects in the user performance evaluation domain. The abstractions used to access these domain entities are referred to as repositories and take the form of C# interfaces. The core layer is used mostly everywhere in the other components and applications.

### Services
The services layer contains the abstractions used to access various services provided by the framework. The services include:

 - Performance Evaluation
 - Performance Processing
 - Assistive Learning
 - Performance Playback
 - Performance Management
 - Logging
 - Scenario Management
 - Serialization

### Infrastructure
The infrastructure contains the implementation of the abstractions of the services and core layers. (Repositories) This layer is where the majority of the application and framework logic resides.

 